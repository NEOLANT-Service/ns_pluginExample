import { P3dbPlugin } from 'libs/Models/types/p3dbplugin.type';
import { IP3DBPluginInstanceCacheService } from './p3db-instance-cache';

/**Кеш, для хранения едиснтвенного экземпляра плагина */
export class P3DBPluginInstanceMemorySingletonCache
    implements IP3DBPluginInstanceCacheService {
    private _isDestucted: boolean;
    private static _cache: Element | undefined;

    constructor() { }
    isExists(name: string | Element): boolean {
        return !!P3DBPluginInstanceMemorySingletonCache._cache;
    }
    get(name: string): Element | undefined {
        if (this._isDestucted) return undefined;
        const plugin = P3DBPluginInstanceMemorySingletonCache._cache;
        if (P3DBPluginInstanceMemorySingletonCache._cache)
            P3DBPluginInstanceMemorySingletonCache._cache!.remove();
        return plugin;

    }
    set(plugin: Element): void {
        if (this._isDestucted) return;
        P3DBPluginInstanceMemorySingletonCache._cache = plugin;
        plugin.remove();
    }
    clear(): void {
        P3DBPluginInstanceMemorySingletonCache._cache = undefined;
    }
    destruct(): void {
        if (this.isExists("")) {
            this._releasePlugin(P3DBPluginInstanceMemorySingletonCache._cache);
        }
    }

    /**Освобождает екземпляр плагина
     * @param plugin экзмепляр плагина
     */
    private _releasePlugin(plugin: Element): void {
        if (plugin) {
            const obj = plugin as unknown as P3dbPlugin;
            try {
                obj.BeginDeInitialization();
                plugin.remove();
            } catch{ }
        }
    }
}

