import { P3dbPlugin, IPluginInformation, IOpenFileDialogOptions, IOpenFileDialogResult } from "../p3dbplugin.type";
import { IP3DBPluginWrapper, IPluginEventArgs } from "./p3dbplugin-wrapper.types";
import { P3DBPluginWrapperCache } from "./p3dbplugin-wrapper-cache";
import { P3DBPluginWrapperScene } from "./p3dbplugin-wrapper-scene";
import { P3DBPluginWrapperSelection } from "./p3dbplugin-wrapper-selection";
import { P3DBPluginWrapperClipping } from "./p3dbplugin-wrapper-clip";
import { P3DBPluginWrapperUI } from "./p3dbplugin-wrapper-ui";
import { P3DBPluginWrapperCamera } from "./p3dbplugin-wrapper-camera";
import { P3DBPluginWrapperFly } from "./p3dbplugin-wrapper.fly";
import { P3DBPluginWrapperLog } from "./p3dbplugin-wrapper-log";
import { P3DBPluginWrapperSearch } from "./p3dbplugin-wrapper-search";
import { P3DBPluginWrapperEvents } from "./p3dbplugin-wrapper-events";
import { P3DBPluginWrapperState } from "./p3dbplugin-wrapper-state";

/**Враппер плагина P3DB */
export class P3DBPluginWrapper
    implements IP3DBPluginWrapper {

    /**Состояние плагина */
    state = new P3DBPluginWrapperState();

    /**Элемент, отвечающий за внедрение плагина в разметку */
    readonly pluginElement: HTMLObjectElement;

    /**Кеш плагина */
    readonly cache: P3DBPluginWrapperCache;

    /**Сцена плагина*/
    readonly scene: P3DBPluginWrapperScene;

    /**Работа с выделенными элементами */
    readonly selection: P3DBPluginWrapperSelection;

    /**Интерфейс плагина */
    readonly ui: P3DBPluginWrapperUI;

    /**Работа с сечениями */
    readonly clipping: P3DBPluginWrapperClipping;

    readonly camera: P3DBPluginWrapperCamera;

    readonly fly: P3DBPluginWrapperFly;

    readonly log: P3DBPluginWrapperLog;

    readonly search: P3DBPluginWrapperSearch;

    readonly events: P3DBPluginWrapperEvents;

    readonly instanceName: string;

    private _isDebugMode: boolean;

    constructor(readonly plugin: P3dbPlugin) {
        this.pluginElement = plugin as any as HTMLObjectElement;
        this.instanceName = this.pluginElement.id;
        this.cache = new P3DBPluginWrapperCache(this);
        this.scene = new P3DBPluginWrapperScene(this);
        this.selection = new P3DBPluginWrapperSelection(this);
        this.clipping = new P3DBPluginWrapperClipping(this);
        this.ui = new P3DBPluginWrapperUI(this);
        this.camera = new P3DBPluginWrapperCamera(this);
        this.fly = new P3DBPluginWrapperFly(this);
        this.log = new P3DBPluginWrapperLog(this);
        this.search = new P3DBPluginWrapperSearch(this);
        this.events = new P3DBPluginWrapperEvents(this);
    }

    destruct() {
        this.events.destruct();
        this.log.destruct();
    }

    /**Синхронная инициализация плагина */
    initialize(logEnabled: boolean = false) {
        this.plugin.PluginInitialize(logEnabled);
    }

    async abortAsync() {
        const aborting = await this.state.beginAborting();
        try {
            this.cache.abort();
            this.scene.abort();
        } catch (ex) {
            this.log.error(ex);
        } finally {
            aborting.resolve();
        }
        return aborting;
    }

    abort() {
        try {
            this.cache.abort();
            this.scene.abort();
        } catch (ex) {
            this.log.error(ex);
            throw ex;
        }
    }

    /**Деинициализация */
    dispose() {
        this.plugin.BeginDeInitialization();
    }

    /**Показывае диалоговеокно загрзк файла */
    openFileDialogShow(options: IOpenFileDialogOptions) {
        const str = this.toJSON<IOpenFileDialogOptions>(options);
        const strResult = this.plugin.OpenFileDialogShow(str);
        return this.fromJSON<IOpenFileDialogResult[]>(strResult);
    }

    /**Вернет информацию о плагине
     * @exeption InvalidOperationException - если вызван до инициализации
     */
    get information() {
        const str = this.plugin.GetInformation();
        return this.fromJSON<IPluginInformation>(str);
    }

    /**Вернет true, если плагин в debug режиме */
    get isDebugMode() {
        if (this._isDebugMode === undefined)
            this._isDebugMode = this.plugin.IsDebugMode;
        return this._isDebugMode;
    }

    /**Находится в режиме прерывания */
    get isInterrupting() {
        return !!this.state.aborting;
    }

    removeEvent(event: string, listner: (_: any, ...args: any[]) => void | EventListener) {
        this.pluginElement.removeEventListener(event, listner);
    }

    addEvent(event: string, listner: (_: any, ...args: any[]) => void | EventListener) {
        this.pluginElement.addEventListener(event, listner);
    }

    fromJSON<T>(str: string): T {
        if (str) {
            return JSON.parse(str) as T;
        }
        return undefined as unknown as T;
    }

    toJSON<T>(obj: T): string {
        return JSON.stringify(obj);
    }

    ASSERT(state: IPluginEventArgs<any>, resolved: string = '', error: string = '') {
        if (state.exception) {
            this.log.error(error + state.exception.message);
            return false;
        }
        return true;
    }
}

