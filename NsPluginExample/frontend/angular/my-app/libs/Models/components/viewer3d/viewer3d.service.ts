import { IP3dbPluginInstance } from './viewer3d.service';
import { WindowService } from '../../../../apps/neosintez-client/src/app/services/window.service';
import { Injectable } from '@angular/core';
import { IP3dbPlugin, P3dbPluginInstance } from './plugin/plugin-intsance';
import { IP3dbPluginOptions } from './plugin/plugin-startup-options';

/**Сервис для управления экземпляром плагина p3d */
@Injectable({
  providedIn: 'root'
})
export class Viewer3dService {
  private static pluginCache: {
    element: HTMLElement
    id: number
  } | undefined;

  get browserSupport(): boolean {
    return (this.window.nativeWindow.ActiveXObject !== undefined || "ActiveXObject" in this.window.nativeWindow);
  }

  constructor(
    private window: WindowService
  ) {
    this.window.nativeWindow.addEventListener("beforeunload", this.destruct.bind(this));
  }

  private destruct(): void {
    //Прибераемся за собой и особождаем русерсы
    //Только для браузеров с поддержкой ActiveX
    if (this.browserSupport) {
      const objects = this.window.nativeWindow.document.querySelectorAll('object');
      if (objects) {
        objects.forEach(x => {
          try {
            (x as unknown as IP3dbPlugin).BeginDeInitialization();
          } catch { }
          x.remove();
        })
      }
      if (typeof this.window.nativeWindow.CollectGarbage === "function") { this.window.nativeWindow.CollectGarbage(); }
    }
  }

  /**Вернет экземпляр плагина
   * @param pluginOptions опции для создания экземпляра плагина
   * @param index индекс экземпляра плагина
   * @param $parent элемент родитель, внутрь которого добавится экземпляр плагина
   * @param fromCache - если true. то вернет плагин из кэша. если таковой имеется, если нет, то создаст новый экземпляр
   * если false то создаст новый экземпляр
   */
  getPluginInstance(pluginOptions: IP3dbPluginOptions, index: number, parent: HTMLElement): P3dbPluginInstance {
    let plugin: HTMLObjectElement;
    this.createPluginInstance(pluginOptions, index, parent);
    plugin = parent.querySelector("object");
    const instance = new P3dbPluginInstance(plugin, pluginOptions);
    return instance;
  }

  /**Создает экземпляр плагина на странице и добавляет его в DOM
   * @param pluginOptions: опции для настройки плагина
   * @param index: номер экземпляра
   * @param $parent: элемнт DOM. в который необходимо добавить компонент
  */
  private createPluginInstance(pluginOptions: IP3dbPluginOptions, index: number, parent: HTMLElement) {
    /**Из-за того что браузер два раза обрабатывает создание плагина -
     * один раз при загрузке template и второй раз, когда добавляет компонент в разметку средствами ангуляр,
     * приходится добавлять его динамически, что позволяет избежать создание нескольких экземпляров */
    const pluginElement = this.window.nativeWindow.document.createElement('object');
    pluginElement.setAttribute("classid", "clsid:13139E6A-CBA5-471C-A0BA-C05860EB3F1A");
    pluginElement.setAttribute("id", this.getPluginId(index));
    pluginElement.hspace = 0;
    pluginElement.vspace = 0;
    pluginElement.border = "0";
    pluginElement.appendChild(this.createParamElement("licenceurl", pluginOptions.LicenceUrl));
    pluginElement.appendChild(this.createParamElement("debug", pluginOptions.Debug.toString()));
    pluginElement.appendChild(this.createParamElement("version", pluginOptions.Version));
    pluginElement.appendChild(this.createParamElement("contributionCullingThreshold", pluginOptions.ContributionCullingThreshold.toString()));

    const createDiv = document.createElement('div');

    createDiv.appendChild(this.createScriptElement("InitializationComplete", index));
    createDiv.appendChild(this.createScriptElement("ContextMenuCommandExecuted", index));
    createDiv.appendChild(this.createScriptElement("ModelLoadingStateChanged", index));
    createDiv.appendChild(this.createScriptElement("Click", index));
    createDiv.appendChild(this.createScriptElement("DoubleClick", index));
    parent.appendChild(createDiv);
    parent.appendChild(pluginElement);
  }


  /**Создает элемент для инициализации плагина */
  private createParamElement(name: string, value: string) {
    const paramElement = document.createElement('param');
    paramElement.name = name;
    paramElement.value = value;
    return paramElement;
  }

  /**Создает элемент для обработки событий от плагина */
  private createScriptElement(eventName: string, index: number) {
    const scriptElement = document.createElement('script');
    scriptElement.setAttribute("for", this.getPluginId(index));
    scriptElement.setAttribute("event", `${eventName}()`);
    scriptElement.textContent = `var evt = document.createEvent("CustomEvent");
    evt.initCustomEvent('${eventName}', true, false, arguments);
    this.dispatchEvent(evt)`;
    return scriptElement;
  }

  private getPluginId(index: number): string {
    return `plugin3d_${index.toString()}`;
  }
}

/**Описание экземпляра плагина */
export interface IP3dbPluginInstance {
  plugin: IP3dbPlugin, pluginElement: HTMLElement
}
