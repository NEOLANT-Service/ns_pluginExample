import { IP3DBPluginWrapper, IP3DBPluginAuthorizationOptions, IPluginEventArgs } from "./p3dbplugin-wrapper.types";
import { Plugin3DEvent, P3dbLoadingState } from "../p3dbplugin.type";
import { P3DBPlugin_CacheManager } from "./p3dbplugin-cache-manager";
import { P3DBPluginErrorCode } from "../p3dbplugin-exceptions.type";
import { Deferred } from 'libs/Shared/types/deferred';

/**Врапер кеша плагина*/
export class P3DBPluginWrapperCache {
    manager: P3DBPlugin_CacheManager;

    constructor(private readonly wrapper: IP3DBPluginWrapper) {
        this.manager = new P3DBPlugin_CacheManager(wrapper);
    }

    /**Вернет массив файлов, загруженных в кеш */
    getModels(): ICachedItem[] {
        const str = this.wrapper.plugin.CacheGetFiles();
        const content = this.wrapper.fromJSON<ICachedItem[]>(str);
        return content || [];
    }

    /**Загрузит файлы в кеш плагина*/
    loadFromUriAsync(items: ICacheLoadItem[], authoriztion?: IP3DBPluginAuthorizationOptions) {
        const payload = this.wrapper.toJSON(items);
        const def = new Deferred<void>();
        const total = items.map(x => x.size).reduce((a, b) => a + b, 0);
        const processLoading = items.map(x => { return { ...x, loaded: 0 } });
        let totalLoaded: number = 0;
        let eventsCount = 0;

        const listner = (e: CustomEvent) => {
            if (this.wrapper.isInterrupting) {
                def.reject();
            }
            try {
                const [data] = e.detail;
                const state = this.wrapper.fromJSON<IPluginEventArgs<{ path: string }>>(data);
                eventsCount++;
                if (this.wrapper.ASSERT(state, "LoadFromUri success complete.", "LoadFromUri error complete: ")) {
                } else {
                    switch (state.exception.number) {
                        case P3DBPluginErrorCode.InvalidOperationException:
                        case P3DBPluginErrorCode.P3DB_InvalidOperationException:
                            def.reject(new Error(""));
                            return;
                        case P3DBPluginErrorCode.OperationCanceledException:
                        case P3DBPluginErrorCode.P3DB_OperationCanceledException:
                            this.wrapper.events.loadingProgressChanged.next({ state: P3dbLoadingState.Aborted, error: state.exception.message });
                            def.resolve();
                        default:
                            def.reject(new Error(state.exception.message));
                    }
                    return;
                }

                if (eventsCount === items.length) {
                    def.resolve();
                }
            } catch (ex) {
                def.reject(ex);
            }
        };

        const progressListener = (e: CustomEvent) => {
            e.stopPropagation();
            const [data] = e.detail;
            const state = this.wrapper.fromJSON<IPluginEventArgs<{ path: string, loaded: number }>>(data)!;
            if (this.wrapper.ASSERT(state, "", "")) {

                const item = processLoading.find(x =>
                    x.path === state.result!.path
                );
                if (item) {
                    item.loaded = state.result!.loaded;
                }
                totalLoaded = processLoading
                    .map(x => x.loaded)
                    .reduce((a, b) => a + b, 0)
                const progress = +(100 / (total / totalLoaded)).toFixed(2);
                this.wrapper.events.loadingProgressChanged.next({ state: P3dbLoadingState.Progress, total: total, loaded: progress });
            } else {
                this.wrapper.events.loadingProgressChanged.next({ state: P3dbLoadingState.Aborted, error: state.exception.message });
            }
        };

        try {
            this.wrapper.addEvent(Plugin3DEvent.CacheLoadFromUriProgressEvent, progressListener);
            this.wrapper.addEvent(Plugin3DEvent.CacheLoadFromUriEvent, listner);
            if (authoriztion)
                this.wrapper.plugin.CacheLoadFromUriAsync(payload, this.wrapper.toJSON(authoriztion));
            else
                this.wrapper.plugin.CacheLoadFromUriAsync(payload);
            def.promise.finally(() => {
                this.wrapper.removeEvent(Plugin3DEvent.CacheLoadFromUriProgressEvent, progressListener);
                this.wrapper.removeEvent(Plugin3DEvent.CacheLoadFromUriEvent, listner);
            })
        } catch (ex) {
            def.reject(ex);
        }

        return def.promise;
    }

    /**Выгружает файл из кеша
     * @param item - описание файла из кеша или URL по которому этот файл быд загружен
    */
    unloadModel(item: ICachedItem | string) {
        let path: string;
        if (typeof (item) === 'string') {
            path = item as string;
        } else {
            path = (item as ICachedItem).path;
        }
        //Игнорируем удаление файла лицензии
        if (~path.indexOf(".lic")) {
            return;
        }
        this.wrapper.plugin.CacheUnload(path);
    }

    /**Выгрузка файлов из кеша */
    unloadModels(items: ICachedItem[] | string[]) {
        if (items) {
            for (let i = 0; i <= items.length - 1; i++) {
                this.unloadModel(items[i]);
            }
        }
    }

    /**Очистит кеш */
    clear() {
        this.wrapper.plugin.CacheClear();
    }

    /**Прерывание загрузки в кеш */
    abort() {
        this.wrapper.plugin.CacheAbortLoading();
    }

    /**Вернет, пустой ли кеш*/
    get isEmpty(): boolean {
        const files = this.getModels();
        return files ? files.length === 0 : true;
    }

    /**Вернет размер занятой памяти кеша в байтах*/
    get totatlSize(): number {
        const fiels = this.getModels();
        return fiels ? fiels.map(x => x.size).reduce((r, i) => {
            return r += i;
        }) : 0;
    }
}

/**Описание закешированного файла*/
export interface ICachedItem {
    /**размер файла */
    size: number;

    /**URL по которому был загружен файл*/
    path: string;
}

/**Модель описания загружаемого файла в кеш плагина */
export interface ICacheLoadItem {
    path: string;

    /**Размер файла в байтах */
    size: number;

    /**Имя файла */
    name: string;

    /**Опции авторизации на сервере. Заполняеются только при загрузке */
    authorizationOptions?: IP3DBPluginAuthorizationOptions
}
