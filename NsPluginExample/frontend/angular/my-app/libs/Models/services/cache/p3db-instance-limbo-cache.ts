import { P3dbPlugin } from 'libs/Models/types/p3dbplugin.type';
import { IP3DBPluginInstanceCacheService } from './p3db-instance-cache';

const P3DBPLUGIN_INSTANCE_OBJECT = 'object';

export class P3DBPluginInstanceLimboCache
    implements IP3DBPluginInstanceCacheService {
    private _isDestructed: boolean;
    private get _elementLibo() {
        return this._getElementLimbo();
    }

    constructor(
        private readonly $window: Window
    ) {}

    /**Вернет, существует ли в кеше именнованный экземпляр плагина*/
    isExists(name: string | Element): boolean {
        if (this._isDestructed) return false;
        let pluginInstance: HTMLObjectElement | undefined;
        if (name instanceof String) {
            pluginInstance = this._findPluginByName(name as string);
        } else {
            pluginInstance = this._findPluginByName((name as Element).getAttribute('id'));
        }
        return !!pluginInstance;
    }

    /**Вернет экземплря плагина из кеша
     * @param name имя экземпляра плагина
     */
    get(name: string): Element | undefined {
        if (this._isDestructed) return;

        const pluginElement = this._getPluginFromLimbo(name);
        if (pluginElement) {
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
        this._setPluginToLimbo(name, plugin);
    }

    /**Производит очистку кеша */
    clear(): void {
        if (this._isDestructed) return;
        const limbo = this._elementLibo;
        const plugins = limbo.querySelectorAll(P3DBPLUGIN_INSTANCE_OBJECT);
        for (let i = 0; i < plugins.length; i++) {
            this._releasePlugin(plugins[i]);
        }
    }

    /** Уничтожение кеша*/
    destruct() {
        if (!this._isDestructed) {
            this.clear();
            const limbo = this._elementLibo;
            limbo.parentNode!.removeChild(limbo);
            this._isDestructed = true;
        }
    }

    /**Верент экземпляр кеша, хранилищем которого является DOM */
    private _getElementLimbo() {
        let elementLimbo: HTMLDivElement = this.$window.document.body.querySelector('#plugin3d_limbo') as HTMLDivElement;
        if (!elementLimbo) {
            elementLimbo = this.$window.document.createElement('div');
            elementLimbo.id = "plugin3d_limbo";
            elementLimbo.setAttribute("style", "height:0; overflow:hidden");
            this.$window.document.body.appendChild(elementLimbo);
        }
        return elementLimbo;
    }

    private _getPluginFromLimbo(name: string) {
        return this._findPluginByName(name);
    }

    private _setPluginToLimbo(name: string, plugin: Element) {
        if (!plugin) return;
        const elementLimbo = this._elementLibo;
        const pluginElement = this._getPluginFromLimbo(name);
        if (pluginElement) {
            this._releasePlugin(pluginElement)
        }
        //this._toggleVisibleScene(plugin.get(0), false);
        elementLimbo.appendChild(plugin.remove()[0]);
    }

    private _findPluginByName(name: string) {
        const elementLimbo = this._elementLibo;
        const plugins = elementLimbo.querySelectorAll(P3DBPLUGIN_INSTANCE_OBJECT);
        for (let i = 0; i < plugins.length; i++) {
            if (plugins.item(i).id === name) {
                return plugins.item(i);
            }
        }
        return undefined;
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