import { ICachedItem } from "./p3dbplugin-wrapper-cache";
import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";

/**Менеджер работы с кешем */
export class P3DBPlugin_CacheManager {
    private static _pluginInstances: Record<string, ICacheManagerItem[]> = {};

    constructor(private wrapper: IP3DBPluginWrapper) {}

    /**Обновление счетчиков кеша.
     * Обновляет для файлов в кеше время их последнего использования
     */
    updateIndexes(files: ICachedItem[] | string[]) {
        let urls: string[];

        urls = (files as any[]).map((x: ICachedItem | string) => {
            if (typeof x === "string") {
                return x as string;
            }
            return x.path as string;
        });

        const lastUse: number = Date.now();
        const cacheManagerStore = this._getInstance(this.wrapper)!;
        for (let i = 0; i <= urls.length - 1; i++) {
            let item = cacheManagerStore.find(
                (x) => x.URL.toLocaleLowerCase() === urls[i].toLocaleString()
            );
            if (item) {
                item.lastUse = lastUse;
                item.counter++;
            } else {
                cacheManagerStore.push({
                    URL: urls[i],
                    lastUse: lastUse,
                    counter: 1,
                });
            }
        }
    }

    /**Нормализация кеша.
     * Производит анализ кеша и его очистку по приоритетам, если это необходимо.
     * @param exclude - список URL которые необходимо исключить из выгрузки
     */
    async normalizeAsync(exclude: string[] = []) {
        const size = this.wrapper.cache.totatlSize;
        if (size > MAX_TOTAL_SIZE) {
            //То начинаем вычищать кеш
            const instance = this._getInstance(this.wrapper);
            //Глупо, но лучше перестраховаться
            if (instance && instance.length > 0) {
                let files = this._orderBy(
                    instance,
                    (x: ICacheManagerItem) => x.counter || 0
                );
                let mediana = this._getMediana(files);
                const candidates = files.filter(
                    (x) =>
                        x.counter < mediana && !exclude.some((z) => z === x.URL)
                );
                if (candidates && candidates.length > 0) {
                    const urls = candidates.map((x) => x.URL);
                    this.wrapper.cache.unloadModels(urls);
                    this._removeItems(instance, urls);
                }
            }
        }
    }

    /**Удаляем индекс */
    removeItem(url: string) {
        const instance = this._getInstance(this.wrapper)!;
        const index = instance.findIndex((x) => x.URL === url);
        if (index > -1) instance.splice(index, 1);
    }

    clear() {
        const instance = this._getInstance(this.wrapper)!;
        instance.splice(0, instance.length);
    }

    private _orderBy<T>(items: T[], predicate: (item: T) => any) {
        return items.sort((a, b) => {
            let valueA = predicate(a);
            let valueB = predicate(b);
            if (valueA > valueB) return 1;
            else if (valueA < valueB) return -1;
            else return 0;
        });
    }

    private _getInstance(
        wrapper: IP3DBPluginWrapper
    ): ICacheManagerItem[] | undefined {
        const pluginInstanceName = this._getName(wrapper);
        if (
            P3DBPlugin_CacheManager._pluginInstances[pluginInstanceName] ===
            undefined
        )
            P3DBPlugin_CacheManager._pluginInstances[pluginInstanceName] = [];
        return P3DBPlugin_CacheManager._pluginInstances[pluginInstanceName];
    }

    private _getName(wrapper: IP3DBPluginWrapper) {
        return wrapper.pluginElement.id;
    }

    private _getMediana(items: ICacheManagerItem[]): number {
        let mediana = 0;
        if (items && items.length > 0) {
            const i = Math.round(items.length / 2);
            if (items.length % 2 === 0) {
                mediana = (items[i].counter + items[i - 1].counter) / 2; //Медианой считаем среднее двух соседних чисел
            } else {
                return (mediana = items[i].counter);
            }
        }
        return mediana;
    }

    private _removeItems(instance: ICacheManagerItem[], urls: string[]) {
        urls.forEach((url) => {
            const index = instance.findIndex((x) => x.URL === url);
            if (index > -1) instance.splice(index, 1);
        });
    }
}

const MAX_TOTAL_SIZE: number = 1e9;

interface ICacheManagerItem {
    /**Полный путь к файлу */
    URL: string;

    /**Время последнего использования на сцене*/
    lastUse: number;

    /**Счетчик использования модели */
    counter: number;
}
