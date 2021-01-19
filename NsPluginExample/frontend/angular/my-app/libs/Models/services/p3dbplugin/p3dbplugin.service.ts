import { Inject, Injectable } from '@angular/core';
import { P3dbPluginOptions } from 'libs/Models/components/viewer3d/plugin/plugin-startup-options';
import { P3dbPlugin, Plugin3DEvent } from 'libs/Models/types/p3dbplugin.type';
import { IP3DBPluginInstanceCacheService } from '../cache/p3db-instance-cache';
import { P3DBPluginInstanceCacheService } from '../cache/p3db-instance-cache.factory';
import { WINDOW } from '../../../Shared/tokens/shareds.token';


/**Сервис для управления экземпляром плагина p3d */
@Injectable({
    providedIn: "root"
})
export class P3DBPluginService {
    private _isDestructed: boolean;

    /**Кеш */
    get cache() {
        return this._pluginInstanceCache;
    }

    constructor(
        @Inject(WINDOW) private readonly _window: any,
        @Inject(P3DBPluginInstanceCacheService) private readonly _pluginInstanceCache: IP3DBPluginInstanceCacheService
    ) {
        const self = this;
        this._window.addEventListener("beforeunload", () => {
            this.destruct.call(self);
        })
    }

    private destruct(): void {
        this._isDestructed = true;
        this.cache.destruct();
        const objects = window.document.querySelectorAll('object');
        for (let i = 0; i < objects.length; i++) {
            const obj = objects[i];
            try {
                (obj as unknown as P3dbPlugin).BeginDeInitialization();
                obj.parentNode!.removeChild(obj);
            } catch{

            }
        }
        if (typeof this._window.CollectGarbage === "function") { this._window.CollectGarbage(); }
    }

    /**Вернет экземпляр плагина
     * @param pluginOptions опции для создания экземпляра плагина
     * @param name индекс экземпляра плагина
     * @param $parent элемент родитель, внутрь которого добавится экземпляр плагина
     * @param fromCache - если true. то вернет плагин из кэша. если таковой имеется, если нет, то создаст новый экземпляр
     * если false то создаст новый экземпляр
     */
    getPluginInstance(pluginOptions: P3dbPluginOptions, name: string, $parent: Element, fromCache: boolean): { plugin: P3dbPlugin, pluginElement: Element, fromCache: boolean } {
        let $plugin: Element;
        let getFromCache: boolean = false;

        const pluginName = this.getPluginName(name);
        if (fromCache) {
            const cachedPlugin = this._pluginInstanceCache.get(pluginName);
            if (cachedPlugin) {
                (cachedPlugin as unknown as P3dbPlugin).SendToLog('Find plugin instance into limo', false);
                cachedPlugin.setAttribute("id", pluginName);
                $parent.append(cachedPlugin);
                $plugin = cachedPlugin;
                getFromCache = true;
            }
        }
        if (!getFromCache) {
            this.createPluginInstance(pluginOptions, pluginName, $parent);
            $plugin = $parent.querySelectorAll("object")[0];
        }
        return {
            plugin: $plugin! as unknown as P3dbPlugin
            , pluginElement: $plugin!
            , fromCache: getFromCache
        };
    }

    /**Инициализирует событий для экземпляра плагина */
    initPluginEvents($parent: Element, name: string) {
        const createDiv = document.createElement('div');
        for (let eventName in Plugin3DEvent) {
            createDiv.appendChild(this.createScriptElement(eventName, name));
        }
        $parent.appendChild(createDiv);
    }

    /**Удаляет обработчики событий экземпляра плагина */
    removePluginEvents($plugin: Element) {
        if ($plugin) {
            for (let eventName in Plugin3DEvent) {
                $plugin.removeEventListener(eventName, () => {});
            }
        }
    }

    /**Создает экземпляр плагина на странице и добавляет его в DOM
     * @param pluginOptions: опции для настройки плагина
     * @param name: имя экземпляра
     * @param $parent: элемнт DOM. в который необходимо добавить компонент
    */
    private createPluginInstance(pluginOptions: P3dbPluginOptions, name: string, $parent: Element) {
        /**Из-за того что браузер два раза обрабатывает создание плагина -
         * один раз при загрузке template и второй раз, когда добавляет компонент в разметку средствами ангуляр,
         * приходится добавлять его динамически, что позволяет избежать создание нескольких экземпляров */
        const pluginElement = document.createElement('object');
        pluginElement.setAttribute("classid", "clsid:13139E6A-CBA5-471C-A0BA-C05860EB3F1A");
        pluginElement.setAttribute("codebase", "/3d/wio3d_setup.exe");
        pluginElement.setAttribute("id", name);
        pluginElement.setAttribute('style', "width:0;height:0;display:block;position:relative");
        pluginElement.hspace = 0;
        pluginElement.vspace = 0;
        pluginElement.border = "0";
        pluginElement.appendChild(this.createParamElement("licence", "// p3dbmngr 192.168.8.100:31 "));
        pluginElement.appendChild(this.createParamElement("debug", pluginOptions.Debug.toString()));
        pluginElement.appendChild(this.createParamElement("version", pluginOptions.Version));

        this.initPluginEvents($parent, name);
        $parent.appendChild(pluginElement);
    }

    /**Создает элемент для инициализации плагина */
    private createParamElement(name: string, value: string) {
        const paramElement = document.createElement('param');
        paramElement.name = name;
        paramElement.value = value;
        return paramElement;
    }

    /**Создает элемент для обработки событий от плагина */
    private createScriptElement(eventName: string, name: string) {
        const scriptElement = document.createElement('script');
        scriptElement.setAttribute("for", name);
        scriptElement.setAttribute("event", `${eventName}()`);
        //scriptElement.textContent = `$(this).triggerHandler("${eventName}", arguments)`;
        scriptElement.textContent = `var evt = document.createEvent("CustomEvent");
        evt.initCustomEvent('${eventName}', true, false, arguments);
        this.dispatchEvent(evt);`;
        return scriptElement;
    }

    getPluginName(name: string): string {
        return 'plugin3d_' + name;
    }
}

interface Plugin3dOptions {
    ContributionCullingThreshold: number;
    Debug: boolean;
    InterViewOptions: InterViewOptions;
    License: string;
    Version: string;
}

interface InterViewOptions {
    Id: string;
    ShowMainMenu: boolean;
}
