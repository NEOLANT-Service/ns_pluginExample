import { IP3dbPluginOptions } from './plugin-startup-options';
import { P3DBPluginCache } from './plugin-cache';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Subject } from 'rxjs';
import { P3DBPluginScene } from './plugin-scene';
import { file } from '@babel/types';


/**Экземпляр плагина */
export class P3dbPluginInstance {
  private plugin: IP3dbPlugin;

  private _isLoaded: boolean;
  private get isLoaded(): boolean {
    return this._isLoaded;
  }
  private set isLoaded(value: boolean) {
    if (value === true)
      this._isLoading = false;
    this._isLoaded = value;
  }

  private _isLoading = false;
  get isLoading(): boolean {
    return this._isLoading;
  }

  private readonly context: ILoadingContext = {
    progress: 0,
    last: Promise.reject()
  };
  private isInitialized: boolean = false;
  private requestedSelection?: ISelectionArgs;

  private lastSelected = [] as number[];
  get hasSelected() {
    return !!this.lastSelected.length;
  }

  /**Событие вызываемое при удачной инициализации плагина*/
  initializationSuccess: Subject<void> = new Subject();

  /**Событие вызываемое при сбое инициализации плагина*/
  initializationError: BehaviorSubject<IInitializationErrorEvent> = new BehaviorSubject(null);

  /**Событие о изменении статуса загрузки модели */
  loadingStateChanged: Subject<ILoadingStateChangedEvent> = new Subject();

  /**Событие, выбора пользовательского контекстного меню */
  contextMenuClick: Subject<number> = new Subject();

  /**Событие, двойного щелчка мыши по объекту модели*/
  doubleClick: Subject<void> = new Subject();

  /**Событие, щелчок мыши по объекту модели */
  click: Subject<void> = new Subject();

  /**Событие о изменении состава выделенных объектов модели */
  selectedChanged: Subject<number[]> = new Subject();

  /**Сцена */
  scene: P3DBPluginScene;

  /**Кеш */
  cache: P3DBPluginCache;

  constructor(private pluginElement: HTMLObjectElement, private options: IP3dbPluginOptions) {
    this.plugin = pluginElement as unknown as IP3dbPlugin;
    this.initInstance();
  }

  destroy() {
    if (this.pluginElement && this.isInitialized) {
      if (this.plugin)
        this.plugin.BeginDeInitialization();
      this.pluginElement.removeEventListener("InitializationComplete", this.pluginEventHandler.bind(this));
      this.pluginElement.removeEventListener("ModelLoadingStateChanged", this.pluginEventHandler.bind(this));
      this.pluginElement.removeEventListener("ContextMenuCommandExecuted", this.pluginEventHandler.bind(this));
      this.pluginElement.removeEventListener("DoubleClick", this.pluginEventHandler.bind(this));
      this.pluginElement.removeEventListener("Click", this.pluginEventHandler.bind(this));
      this.pluginElement.parentElement.removeChild(this.pluginElement);
    }
  }

  /**Загружает модель */
  loadModel(files: ILoadModelInfo[]) {
    this.resetSelection();
    this.selectedChangedHandler(false);
    if (this.isLoading) {
      this.plugin.AbortModelLoading();
    }
    this.isLoaded = false;
    this._isLoading = true;
    try {

      this.plugin.LoadModel(JSON.stringify({ Content: files }));
    } catch (ex) {
      this.isLoaded = false;
      this._isLoading = false;
      console.log(ex);
    }
  }

  getSelected() {
    if (this.isLoaded) return this.evalResult<number[]>(this.plugin.GetSelectedUIDs());
    else {
      return [];
    }
  }

  /**Сброс выделения */
  resetSelection() {
    this.isInitialized && this.plugin.ResetSelection();
  }

  /** выделить элементы на модели */
  selectElements(args: ISelectionArgs) {
    if (!args || !args.groups) throw new Error("invalid args");
    this.plugin.SelectElementGroups(JSON.stringify({ g: args.groups }), args.mode);
    if (args.groups.some(g => !!g.Select))
      this.selectedChangedHandler(true);
  }

  clip(ids: number[]) {
    this.resetClip();

    if (this.isLoaded) this.plugin.Clip(JSON.stringify({
      ids
    }));
  }

  resetClip() {
    this.isInitialized && this.plugin.ResetClip();
  }

  setCameraView(args: CameraViewArgs) {
    if (this.isLoaded) this.plugin.SetCameraView(args.position.x, args.position.y, args.position.z, -args.view.azimuth, -args.view.zenith, args.view.fov);
  }

  centerViewOnSelected() {
    this.isInitialized && this.plugin.CenterViewOnSelected();
  }

  /**Установка цвета заливки фона плагина */
  SetBackgroundColor(ragbs: string) {
    this.plugin.SetBackgroundColor(ragbs);
  }

  /**Добавление пунктов пользовательского контекстного меню */
  AddContextMenuCommands(menu: any) {
    this.plugin.AddContextMenuCommands(JSON.stringify(menu));
  };

  /**Показать/ скрыть GUI плагина */
  ToggleGUI(show: boolean): void {
    this.plugin.ToggleGUI(show);
  }

  /** Получить список доступных облетов */
  getFlybys(): string[] {
    this.ensureLoaded();
    const flybys = this.plugin.GetFlybys();
    return flybys && JSON.parse(flybys);
  }

  /** Установить текущий облет */
  setFlyby(name: string) {
    this.ensureLoaded();
    this.plugin.SetFlyby(name);
  }

  /** Запустить текущий облет */
  startFlyBy() {
    this.ensureLoaded();
    this.plugin.StartFlyBy();
  }

  /** Приостановить текущий облет */
  pauseFlyBy() {
    this.ensureLoaded();
    this.plugin.PauseFlyBy();
  }

  /** Перейти к конкретной точке */
  setFlyByPositon(percent: number) {
    this.ensureLoaded();
    this.plugin.SetFlyByPositon(percent);
  }

  getLocalFileInformation() {
    const dialogResultStr = this.plugin.GetLocalFileInformation();
    const dialogResult = JSON.parse(dialogResultStr) as IDialogResult;

    function removeExtension(filename: string) {
      const i = filename.lastIndexOf('.p3db');
      return i > -1 ? filename.substring(0, i) : filename;
    }

    function getFilename(path: string) {
      const i = path.lastIndexOf("\\");
      return removeExtension(i > -1 ? path.substring(i + 1) : path);
    };

    if (dialogResult.Files) {
      dialogResult.Files = dialogResult.Files.map(x => {
        return { ...x, FileName: getFilename(x.Name) }
      })
    }
    return dialogResult;
  }

  /**Инициализация экземпляра плагина */
  private initInstance() {
    this.pluginElement.addEventListener("InitializationComplete", this.pluginEventHandler.bind(this));
    this.pluginElement.addEventListener("ModelLoadingStateChanged", this.pluginEventHandler.bind(this));
    this.pluginElement.addEventListener("ContextMenuCommandExecuted", this.pluginEventHandler.bind(this));
    this.pluginElement.addEventListener("DoubleClick", this.pluginEventHandler.bind(this));
    this.pluginElement.addEventListener("Click", this.pluginEventHandler.bind(this));
    this.plugin.BeginInitialization(this.options.Debug);
  }

  private pluginEventHandler(e: CustomEvent) {
    switch (e.type) {
      case "InitializationComplete":
        this.initializationCompleteHandler.apply(this, e.detail);
        break;
      case "ModelLoadingStateChanged":
        this.modelLoadingStateChangedHandler.apply(this, e.detail);
        break;
      case "ContextMenuCommandExecuted":
        this.contextMenuCommandHandler.apply(this, e.detail);
        break;
      case "DoubleClick":
        this.doubleClickHandler.apply(this, e.detail);
        break;
      case "Click":
        this.clickHandler.apply(this, e.detail);
        break;
    }
  }

  /**Реация на событие  инициализации плагина*/
  private initializationCompleteHandler(state: P3dbInitializationState, error?: string) {
    this.pluginElement.removeEventListener("InitializationComplete", this.pluginEventHandler)
    if (state === P3dbInitializationState.Successful) {
      this.isInitialized = true;
      this.scene = new P3DBPluginScene(this.plugin);
      this.cache = new P3DBPluginCache(this.plugin);
      this.initializationSuccess.next();
    } else {
      this.isInitialized = false;
      this.initializationError.next({ state, error });
    }
  }

  /**Реация на событие изменения статуса загрузки модели */
  private modelLoadingStateChangedHandler(state: P3dbLoadingState, total: number, loaded: number, error?: string) {
    const progress = +(loaded / total * 100).toFixed(0);
    //Костыль, позволяющий не отправлять сообщения Process после того как отправлено событие Loaded
    switch (state) {
      case P3dbLoadingState.Loaded:
        this.isLoaded = true;
        this.loadingStateChanged.next({ state, total, loaded, progress, error });
        break;
      case P3dbLoadingState.Progress:
        if (!this.isLoaded) {
          if (this.context.progress < progress) {
            this.context.progress = progress;
            this.loadingStateChanged.next({ state, total, loaded, progress, error });
          }
        }
        break;
      case P3dbLoadingState.Failed:
      case P3dbLoadingState.Aborted:
        this.isLoaded = false;
        this._isLoading = false;
        if (this.context.progress < progress) {
          this.context.progress = progress;
        }
        this.loadingStateChanged.next({ state, total, loaded, progress, error });
        break;
    }
  }

  /**Реация на работу с пунктами пользовательского контекстного меню*/
  private contextMenuCommandHandler(id: number) {
    this.contextMenuClick.next(id);
  }

  /**Реация на двойной щелчок мышью по объекту модели */
  private doubleClickHandler() {
    this.doubleClick.next();
  }

  /**Реация на щелчок мышью по объекту модели*/
  private clickHandler() {
    this.click.next();
    this.selectedChangedHandler(true);
  }

  /**Реация на изменение состава выделенных объектов модели*/
  private selectedChangedHandler(forceEvent: boolean) {
    if (this.isLoaded) {
      let uids = this.getSelected();

      let hash = this.lastSelected.reduce((r, i) => (r[i] = null, r), {} as { [uid: string]: null });
      if (this.lastSelected.length === uids.length && this.lastSelected.every(id => id in hash)) return;

      this.lastSelected.splice(0, this.lastSelected.length);
      this.lastSelected.push(...uids);
    } else {
      if (!this.lastSelected.length) return;
      this.lastSelected.splice(0, this.lastSelected.length);
    }
    if (forceEvent)
      this.selectedChanged.next(this.lastSelected.slice());
  }

  private evalResult<T>(r: string): T {
    return r && (JSON.parse(r).array || []);
  };

  private ensureLoaded() {
    if (!this.isLoaded) throw new Error("Model is not loaded");
  }
}

/**Интерфейс плагина P3DB */
export interface IP3dbPlugin {
  BeginInitialization(debug: boolean): void;
  BeginDeInitialization(): void;

  LoadModel(content: string): void;
  AbortModelLoading(): void;

  SelectElementGroups(groups: string, mode: SelectionMode): void;
  ResetSelection(): string;
  GetSelectedUIDs(): string;
  GetAncestors(uid: number): string;

  SetBackgroundColor(rgba: string): void;
  ToggleGUI(show: boolean): void;
  AddContextMenuCommands(commands: string): void;

  Clip(uids: string): void;
  ResetClip(): void;

  SetCameraView(x: number, y: number, z: number, azimuth: number, zenith: number, fov: number): void;
  CenterViewOnSelected(): void;

  GetFlybys(): string;
  SetFlyby(name: string): void;
  StartFlyBy(): void;
  PauseFlyBy(): void;
  SetFlyByPositon(percent: number): void;

  /**Отправляет сообщение в логи плагина*/
  SendToLog(message: string, isError: boolean): void;

  /**Добавит файли в сцену*/
  Scene_AddFiles(files: string): void;

  /**Вернет список файлов со сцены */
  Scene_GetFiles(): string;

  /**Очитсит сцену */
  Scene_Clear(): void;

  /**Удалит загруженные файлы в сцену */
  Scene_RemoveFiles(files: string);

  /**Вызовет диалоговое окно плагина работы с файлами и вернет информацию о локальных файлах, выбранных пользователемы*/
  GetLocalFileInformation(): string;


  /**Очистит кеш плагина */
  Cache_Clear();

  /**Удалит файлы из кэша */
  Cache_RemoveFiles(files: string);

  /**Вернет список файлов, храняшихся в кеше */
  Cache_GetFiles();

}

/**Статусы инициализации плагина */
export enum P3dbInitializationState {
  Successful = 1,
  Failed = 2,
  Expired = 3, // срок лицензии истек
  Obsolete = 4 // версия плагина устарела (не соот. требуемой сайтом)
}

/**Статусы загрузки модели */
export enum P3dbLoadingState {
  /**В процессе загрузки*/
  Progress = 1,
  /**Модель загружена */
  Loaded = 2,
  /**Произошел сбой в процессе загрузки*/
  Failed = 3,
  /**Загрузк отменена */
  Aborted = 4
}

/**Свойства камеры наблюдателя */
export interface CameraViewArgs {
  position: {
    x: number,
    y: number,
    z: number
  };
  view: {
    azimuth: number,
    zenith: number,
    fov: number
  }
}

/**Описание события ошибки инциализации */
export interface IInitializationErrorEvent {
  state: P3dbInitializationState,
  error: string
}

/**Описание события изменения стутса загрузки модели */
export interface ILoadingStateChangedEvent {
  state: P3dbLoadingState,
  total: number,
  loaded: number,
  progress: number;
  error?: string
}

/**Описание контекста загрузки */
interface ILoadingContext {
  /**Прогресс загрусски */
  progress: number;

  last: Promise<void>;
}

export interface ISelectionArgsGroup {
  Ids?: number[];
  All?: boolean;

  Color?: string;
  Select?: boolean;
  Fit?: boolean;
}

export interface ISelectionArgs {
  groups: ISelectionArgsGroup[];
  mode: SelectionMode;
}

/**Статусы, описывающие состняие выбора файлов моделей пользователей */
export enum DialogResultState {
  Success = 1,
  Cancel = 2,
  Error = 3
}

/**Информация о файле */
export interface IDialogFile {
  Name: string;
  Exist: boolean;
  LastUpdate: Date;
  Size: number;
  FileName: string;
}

/**Результат работы файлового диалога*/
export interface IDialogResult {
  State: DialogResultState;
  Error?: string;
  Files?: IDialogFile[]
}

export enum SelectionMode {
  All = 0,
  Only = 1,
  // Except = 2 - not implemented
}

/**Описание загружаемого файла модели */
export interface ILoadModelInfo {
  Name: string;
  Size: number;
  URL: string;
  Hash?: string;
}
