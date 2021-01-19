import { P3dbPlugin } from 'libs/Models/types/p3dbplugin.type';
import { IP3DBPluginInstanceCacheService } from './p3db-instance-cache';

export class P3DBPluginInstanceMemoryCache
    implements IP3DBPluginInstanceCacheService {
    private _isDestructed: boolean;
    private static _cache: Record<string, Element | undefined> = {};

    constructor() { }

    /**Вернет, существует ли в кеше именнованный экземпляр плагина*/
    isExists(name: string | Element): boolean {
        if (this._isDestructed) return false;
        let pluginInstance: Element | undefined;
        if (name instanceof String) {
            pluginInstance = this._findPluginByName(name as string);
        } else {
            pluginInstance = this._findPluginByName((name as Element).getAttribute('id'))
        }
        return !!pluginInstance;
    }

    /**Вернет экземплря плагина из кеша
     * @param name имя экземпляра плагина
     */
    get(name: string): Element | undefined {
        if (this._isDestructed) return;
        const pluginElement = this._getPluginFromCache(name);
        if (pluginElement) {
            P3DBPluginInstanceMemoryCache._cache[name] = undefined;
            return pluginElement;
        }
        return undefined;
    }

    /**Сохранит экземпляр плагина в кеше
     * @param name имя экземпляра плагина
     */
    set(plugin: Element) {
        if (this._isDestructed) return;
        const name = plugin.getAttribute('id');
        this._setPluginToCache(name, plugin);
    }

    /**Производит очистку кеша */
    clear(): void {
        if (this._isDestructed) return;
        P3DBPluginInstanceMemoryCache._cache = {};
    }

    /** Уничтожение кеша*/
    destruct() {
        if (!this._isDestructed) {
            this.clear();
            delete P3DBPluginInstanceMemoryCache._cache
            this._isDestructed = true;
        }
    }

    private _getPluginFromCache(name: string) {
        return this._findPluginByName(name);
    }

    private _setPluginToCache(name: string, plugin: Element) {
        if (!plugin) return;
        const pluginElement = this._getPluginFromCache(name);
        if (pluginElement) {
            this._releasePlugin(pluginElement);
        }
        //this._toggleVisibleScene(plugin.get(0), false);
        P3DBPluginInstanceMemoryCache._cache[name] = plugin;
    }

    private _findPluginByName(name: string) {
        return P3DBPluginInstanceMemoryCache._cache[name];
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

