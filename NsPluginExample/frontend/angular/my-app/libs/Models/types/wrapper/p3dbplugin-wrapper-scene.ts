import { IP3DBPluginWrapper, IPluginEventArgs } from "./p3dbplugin-wrapper.types";
import { P3DBSceneLoadMode, Plugin3DEvent } from "../p3dbplugin.type";
import { ICachedItem } from "./p3dbplugin-wrapper-cache";
import { P3DBPlugin_LoadManager } from "./p3dbplugin-load-manager";
import { Deferred } from 'libs/Shared/types/deferred';

/**Обертка над сценой плагина P3DB */
export class P3DBPluginWrapperScene {
    readonly manager: P3DBPlugin_LoadManager;
    private _loadingLock: Deferred<void> | null;

    constructor(private readonly wrapper: IP3DBPluginWrapper) {
        this.manager = new P3DBPlugin_LoadManager(wrapper);
    }

    loadFromFile(path: string, mode: P3DBSceneLoadMode) {
        const def = new Deferred<void>();
        const listner = (e: CustomEvent) => {
            const [data] = e.detail;
            const state = this.wrapper.fromJSON<IPluginEventArgs<{ path: string }>>(data);
            if (this.wrapper.ASSERT(state)) {
                def.resolve();
            } else {
                def.reject(new Error(state.exception.message));
            }
        }

        try {
            this.wrapper.addEvent(Plugin3DEvent.SceneLoadFromFileEvent, listner);
            def.promise.finally(() => {
                this.wrapper.removeEvent(Plugin3DEvent.SceneLoadFromFileEvent, listner)
            });
            this.wrapper.plugin.SceneLoadFromFileAsync(path, mode);
        } catch (ex) {
            def.reject(ex);
        }

        return def.promise;
    }

    loadFromCacheAsync(item: ICachedItem | string, mode: P3DBSceneLoadMode) {
        const def = new Deferred<void>();
        let path: string;
        if (typeof (item) === 'string') {
            path = item as string;
        } else {
            path = (item as ICachedItem).path;
        }

        const listner = (e: CustomEvent) => {
            if (this.wrapper.isInterrupting)
                def.reject();
            try {
                const [data] = e.detail;
                const state = this.wrapper.fromJSON<IPluginEventArgs<{ path: string }>>(data);
                if (this.wrapper.ASSERT(state, "LoadFromCache success complete", "LoadFromCache error complete: ")) {
                    this.wrapper.cache.manager.updateIndexes([item as ICachedItem]);
                    def.resolve();
                } else {
                    def.reject(new Error(state.exception.message));
                }
            } catch (ex) {
                def.reject(ex);
            }
        };

        try {
            this.wrapper.addEvent(Plugin3DEvent.SceneLoadFromCacheEvent, listner);
            this.wrapper.plugin.SceneLoadFromCacheAsync(path, mode);
            def.promise
                .finally(() => {
                    this.wrapper.removeEvent(Plugin3DEvent.SceneLoadFromCacheEvent, listner);
                })
        } catch (ex) {
            this.wrapper.log.error("LoadFromCache error complete: " + ex.message+" "+path);
            throw new Error(ex);
        }

        return def.promise;
    }

    /**Очищает сцену от моделей */
    clear() {
        this.wrapper.plugin.SceneClear();
    }

    /**Вернет список файлов, загруженных в сцену */
    getModels(): ISceneItem[] {
        const str = this.wrapper.plugin.SceneGetFiles();
        const result = this.wrapper.fromJSON<ISceneItem[]>(str);
        return result || [];
    }

    /**Выгрузит файл из сцены */
    unloadModel(item: ISceneItem | string) {
        const path: string = typeof (item) === 'string' ? item as string : item.path;
        this.wrapper.plugin.SceneUnload(path);
    }

    cloak(hide: boolean, color: string = 'FFFFFF') {
        this.wrapper.plugin.SceneCloak(hide,color);
    }

    abort() {
        this.wrapper.plugin.SceneAbortLoading();
    }

    beginUpdate() {
        this.wrapper.scene.cloak(true);
    }

    endUpdate() {
        this.wrapper.scene.cloak(false);
    }

    getCount() {
        return this.getModels().length;
    }

    get isEmpty(): boolean {
        const files = this.getModels();
        return files ? files.length === 0 : true;
    }

    get settings(): ISceneSettings {
        const str = this.wrapper.plugin.SceneSettings;
        return this.wrapper.fromJSON<ISceneSettings>(str)!;
    }

    set settings(value: ISceneSettings) {
        const str = this.wrapper.toJSON(value);
        this.wrapper.plugin.SceneSettings = str;
    }

    /**Количество моделей в сцене */
    get count(): number {
        const files = this.getModels();
        return files.length;
    }

    set visible(value: boolean) {
        this.wrapper.plugin.SceneVisible(value);
    }

    private async loadingLock() {
        this._loadingLock && await this._loadingLock.promise;
        this._loadingLock = new Deferred<void>();
    }

    private loadingUnlock() {
        this._loadingLock && this._loadingLock.resolve();
        this._loadingLock = null;
    }
}

export interface ISceneItem {
    size: number;
    path: string;
    name: string;
}

/**Настройки сцены */
export interface ISceneSettings {
    Aspect: {
        Detailed: number;
        Insulation: number;
        Operation: number;
        Maintenance: number;
    },
    Colors: {
        Npl_View_CLR_BG0: string;//RGB
        Npl_View_CLR_BG1: string;//RGB
        Npl_View_CLR_SEL: string;//RGB
        Npl_View_CLR_HLT: string;//RGB
        Npl_View_CLR_FND: string;//RGB
        Npl_View_CLR_RLN: string;//RGB
    }
}

/**Описание модели, для загрузки в сцену */
export interface ISceneLoad {
    name: string;
    /**ожидаемый размер файла, если неизвестен -1*/
    size: number;
    /**путь к файлу, может быть как на диске, так и в сети интернет */
    path: string;
}

export enum FileLoadState {
    /**ошибка 0 - начальное значение21 - загрузка завершена */
    Error = -1,
    None = 0,
    /**Загрузка завершена */
    LoadComplete = 21
}
