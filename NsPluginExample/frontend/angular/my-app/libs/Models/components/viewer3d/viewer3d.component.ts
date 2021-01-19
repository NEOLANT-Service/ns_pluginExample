import { P3DBPluginAuthService } from './../../services/p3dbplugin/p3dbplugin-auth.service';
import {
  IOpenFileDialogResult,
  ViewOptionsType
} from './../../types/p3dbplugin.type';
import { ModelsApiService } from '../../../../apps/neosintez-client/src/app/services/backend/models-api.service';
import {
  Component,
  OnInit,
  ElementRef,
  AfterViewInit,
  OnDestroy,
  Input,
  ViewChild,
  Output,
  EventEmitter,
  NgZone
} from '@angular/core';
import {
  IInitializationErrorEvent,
  P3dbLoadingState,
  SelectionMode,
  ISelectionArgsGroup,
  ILoadModelInfo
} from './plugin/plugin-intsance';
import { Subject } from 'rxjs';
import { _getOptionScrollPosition } from '@angular/material/core';
import { P3dbPluginOptions } from './plugin/plugin-startup-options';
import { P3DBPluginAvailableService } from 'libs/Models/services/p3dbplugin/p3dbplugin-available.service';
import { P3DBPluginService } from 'libs/Models/services/p3dbplugin/p3dbplugin.service';
import { P3DBPluginWrapper } from 'libs/Models/types/wrapper/p3dbplugin-wrapper';
import { Deferred } from 'libs/Shared/types/deferred';
import {
  IP3DBPluginException,
  P3DBPluginErrorCode
} from 'libs/Models/types/p3dbplugin-exceptions.type';
import {
  P3dbPlugin,
  P3DBSceneLoadMode
} from 'libs/Models/types/p3dbplugin.type';

export const fadeColor = '0000000A';

/**Компонент-обертка для работы с плагином P3DB
 *
 * @Input modelId - Идентификатор модели, которую необходимо загрузить в плагин
 * @Input options - Настройки для инициализации плагина
 */
@Component({
  selector: 'app-viewer3d',
  templateUrl: './viewer3d.component.html',
  styleUrls: ['./viewer3d.component.less'],
  providers: [P3DBPluginService, P3DBPluginAvailableService]
})
export class Viewer3dComponent implements OnInit, AfterViewInit, OnDestroy {
  private current: IViewer3DModel = <IViewer3DModel>{ Ids: [] };

  private _modelId: number;
  private $plugin: HTMLObjectElement;
  private cached: boolean;
  annotationSettingsAvailable: boolean = false;
  private appName: string;
  private _debug: boolean;
  pluginInstanceInfo: {
    plugin: P3dbPlugin;
    pluginElement: Element;
    fromCache: boolean;
  };
  private showGUI: boolean;
  @Input() set modelId(value: number) {
    this._modelId = value;
    this.current = { Id: value, Ids: [] } as IViewer3DModel;
  }
  get modelId() {
    return this._modelId;
  }

  private _options: P3dbPluginOptions;
  /**Опции плагина */
  @Input() set options(value: P3dbPluginOptions) {
    if (!this._initialize) {
      this._options = value;
      this._debug = value && value.Debug;
      if (this._options) this._initInstance();
    }
  }
  get options() {
    return this._options;
  }

  private _viewMode: ViewMode | undefined;
  @Input() set viewMode(value: ViewMode | undefined) {
    this._viewMode = value;
    this.select(this._viewMode, false);
  }
  get viewMode() {
    return this._viewMode;
  }

  @Input() name: string = 'models-section';
  @Input() noCacheLast: boolean;

  @Output() selectedChanged = new EventEmitter<number[]>();

  @ViewChild('pluginContainer', { static: true })
  protected pluginContainer: ElementRef;

  private pluginInstance: P3dbPlugin;
  private _pluginWrapper: P3DBPluginWrapper;
  isSupported: boolean;
  private _initialize: boolean = false;
  pluginError: IInitializationErrorEvent;
  loadingProcessState: ILoadingProcessState;
  loadingProcessStates = LoadingState;
  needInstall: boolean = false;

  get hasSelected() {
    return !!this.current.Ids.length;
  }

  readonly initializationStates = InitializationState;
  private _state = InitializationState.Uninitialized;
  get state() {
    return this._state;
  }

  private readonly context = {
    loading: undefined as Deferred<void> | undefined,
    lock: undefined as ResolveOnlyDeferred | undefined,
    last: Promise.reject<void>(),
    /**legacy */
    id: undefined as number | undefined,
    name: undefined as string | undefined,
    progress: 0
  };

  get isInitialized() {
    return !!this._pluginWrapper;
  }

  private logger: ILogger = {
    warn: m => {
      let self = this;
      if (self._debug) {
        if (this.isInitialized) this._pluginWrapper.log.info(m);
      }
    }
  };

  private _loadingState = LoadingState.Empty;
  get loadingState() {
    return this._loadingState;
  }

  private ngUnsubscribe = new Subject<void>();

  constructor(
    private readonly _viewer3dService: P3DBPluginService,
    private readonly _modelsApi: ModelsApiService,
    private readonly _ngZone: NgZone,
    private readonly _pluginAvailableService: P3DBPluginAvailableService,
    private readonly _p3dbAuthService: P3DBPluginAuthService
  ) {}

  ngOnInit() {}

  ngAfterViewInit() {
    if (this.options) {
      this._initInstance();
    }
  }

  /**Инициализация экземпляра плагина */
  private _initInstance() {
    const self = this;
    this.isSupported = self._pluginAvailableService.isAvailable();
    if (!this.isSupported) {
      return;
    }
    if (!self._initialize) {
      self._ngZone.run(() => {
        try {
          self._state = InitializationState.Initializing;
          self.pluginInstanceInfo = self._viewer3dService.getPluginInstance(
            self.options,
            self.name,
            self.pluginContainer.nativeElement,
            !self.noCacheLast
          );
          self.pluginInstance = self.pluginInstanceInfo.plugin;
          self.$plugin = self.pluginInstanceInfo
            .pluginElement as HTMLObjectElement;
          const plugin = self.pluginInstanceInfo.plugin;
          if (!plugin) throw new Error('Plugin element is missing');
          self._pluginWrapper = new P3DBPluginWrapper(plugin);
          if (self.pluginInstanceInfo.fromCache === true) {
            self.cached = true;
            self.context.id = 1; //legacy
            self._viewer3dService.initPluginEvents(
              self.pluginContainer.nativeElement,
              self._viewer3dService.getPluginName(self.name)
            );
            self.context.last = Promise.resolve();
          } else {
            self.cached = false;
          }
          self._initializePlugin();
          self._state = InitializationState.Initialized;
          self._setupPlugin(self.$plugin);
        } catch (e) {
          const error = e as IP3DBPluginException;
          this.pluginError = e;
          switch (error.number) {
            case P3DBPluginErrorCode.P3DB_LicenseException:
              self._state = InitializationState.LicenceFailed;
              break;
            case P3DBPluginErrorCode.P3DB_LicenceExpired:
              self._state = InitializationState.LicenceExpired;
              break;
            case P3DBPluginErrorCode.InvalidOperationException:
            case P3DBPluginErrorCode.NotImplementedException:
              self._state = InitializationState.PluginIncompatible;
              break;
            default:
              self._state = InitializationState.Unavailable;
              this.needInstall = true;
          }
          self.logger.warn(e.message);
          throw e;
        }
        if (self._state === InitializationState.Initialized) {
          self._initialize = true;
        }
      });
    }
  }

  private _initializePlugin() {
    /**Скрываем плагин принудительно*/
    const $plugin = this._pluginWrapper.pluginElement;
    this._hidePlugin($plugin);
    if (this.cached) {
      return;
    }
    this._pluginWrapper.initialize(this._debug);
  }

  /**Настройка плагина */
  private _setupPlugin($plugin: Element) {
    // инициализировать UI
    let sceneSettings = this._pluginWrapper.scene.settings;
    if (sceneSettings && sceneSettings.Colors) {
      sceneSettings.Colors.Npl_View_CLR_BG1 = 'FFFFFF';
      this._pluginWrapper.scene.settings = sceneSettings;

      this._initContextMenu();

      //Установка уровня детализации
      this._pluginWrapper.plugin.ViewSetMode(
        ViewOptionsType.Npl_View_DROP,
        this.options.ContributionCullingThreshold
      );

      const self = this;
      // подписаться на события
      this._pluginWrapper.events.click.subscribe({
        next: () => {
          // $plugin.parent().trigger("click").scope().$applyAsync(); // пробросить событие клика вверх, чтобы он мог был перехвачен и обработан родительскими элементами
        }
      });

      this._pluginWrapper.events.doubleClick.subscribe({
        next: () => {
          // self.find();
        }
      });
      this._pluginWrapper.events.selectedChanged.subscribe({
        next: x => {
          // self.onSelectedChanged(x);
        }
      });
      this._pluginWrapper.events.loadingProgressChanged.subscribe({
        next: x => {
          self._loadingChangedHandler(x.state, x.total, x.loaded, x.error);
        }
      });
    }
  }

  /**Метод, обрабатывающий процесс загрузки */
  private _loadingChangedHandler(
    state: P3dbLoadingState,
    total?: number,
    loaded?: number,
    error?: string
  ) {
    this.loadingProcessState = {
      ...this.loadingProcessState,
      state,
      progress: loaded,
      error
    };
    if (state === P3dbLoadingState.Progress) {
      const progress = loaded!;
      if (this.context.progress < progress) {
        this.context.progress = progress;
      }
    }
  }

  private _initContextMenu() {
    const commands = {
      1001: {
        actionNameHandler: '_findNameHandler',
        caption: 'find'
      },
      1002: {
        actionNameHandler: '_toggleMenuHandler',
        caption: 'toggleMenuHandler'
      }
    };

    this._pluginWrapper.ui.addContextMenu({
      Group: this.appName,
      Commands: Object.entries(commands).map(([id, v]) => ({
        Id: id,
        Name: v.caption
      }))
    });

    this._pluginWrapper.events.contextMenuClick.subscribe({
      next: (x: keyof typeof commands) => {
        ((this as unknown) as {
          [n: string]: () => void;
        })[commands[x].actionNameHandler](); // вызвать команду сервиса по её id
      }
    });
  }

  private _hidePlugin($plugin: HTMLObjectElement) {
    this._ngZone.runOutsideAngular(() => {
      if ($plugin && !this.noCacheLast) {
        $plugin.style.position = 'relative';
        $plugin.style.width = '1px';
        $plugin.style.height = '1px';
      }
    });
  }

  private _showPlugin($plugin: HTMLObjectElement) {
    this._ngZone.runOutsideAngular(() => {
      if ($plugin) {
        $plugin.style.width = '100%';
        $plugin.style.height = '100%';
        $plugin.style.left = '0';
        $plugin.style.top = '0';
        $plugin.style.display = 'block';
      }
    });
  }

  /**загрузка модели
   * @param modelId Идентфикатор модели Неосинтеза
   */
  loadModel(modelId: number) {
    return (this.context.last = this._load(modelId));
  }

  private async _load(modelId: number) {
    if (!modelId) {
      this._loadingState = LoadingState.Empty;
      this._state = InitializationState.Initialized; //эмулируем для разметки что плагин инициализирован
      throw new Error('modelId is missing');
    } else {
      this.resetSelected();
    }
    if (!this.isInitialized) {
      this._initInstance();
    }

    await this.loadLock(); // блокировка вызова, на случай нескольких синхронных вызовов load подряд, чтобы при последующем вызове отработал abort предыдущего
    await this.abort();
    this._loadingState = LoadingState.Loading;
    this.context.progress = 0;
    this.loadUnlock();

    try {
      const content = await this._modelsApi.getContent(modelId).toPromise();

      if (this._pluginWrapper.state.aborting) {
        this._pluginWrapper.state.aborting.resolve();
        throw new Error('');
      }
      this.context.loading = new Deferred<void>();
      const p3dbAuthorization = this._p3dbAuthService.getAuthContext();

      await this._pluginWrapper.scene.manager.loadAsync(
        content.map(x => {
          return { name: x.Name, size: x.Size, path: x.URL };
        }),
        p3dbAuthorization
      );
      this._loadingState = LoadingState.Loaded;
      this.context.loading = undefined;
      this._loadingState = LoadingState.Loaded;
      this.context.id = modelId;
    } catch (e) {
      this._loadingState =
        e || e.message ? LoadingState.Failed : LoadingState.Empty;
      if (this.loadingState === LoadingState.Failed) {
        //await this._showSystemInfoHandler();
        this._pluginWrapper.scene.clear();
        if (e) {
          this.logger.warn(e.message || e);
        }
        throw e;
      }
    } finally {
      this._showPlugin(this.$plugin as HTMLObjectElement);
      // await this._applyInterViewOptionsAsync(modelId);
    }
  }

  private async loadLock() {
    this.context.lock && (await this.context.lock.promise);
    this.context.lock = new Deferred<void>();
  }

  private loadUnlock() {
    this.context.lock!.resolve();
    this.context.lock = undefined;
  }

  private async abort() {
    if (this._pluginWrapper && this._pluginWrapper.state.aborting)
      await this._pluginWrapper.state.aborting;

    if (this._loadingState === LoadingState.Loading) {
      const aborting = await this._pluginWrapper.abortAsync();
      await aborting;
    }
  }

  resetSelected() {
    this.isInitialized && this._pluginWrapper.selection.resetSelection();
  }

  toggleGUI() {
    if (this._initialize) {
      this.showGUI = !this.showGUI;
      this._pluginWrapper.ui.setControlsVisible(
        +this.showGUI,
        +this.showGUI,
        +this.showGUI,
        +this.showGUI
      );
    }
  }

  select(mode: ViewMode, fit: boolean) {
    if (this.pluginInstance && this._initialize) {
      const selectedUIDs = JSON.parse(this.pluginInstance.GetSelectedUIDs());
      this.current.Ids = selectedUIDs && selectedUIDs.array;
      const ids = this.current && this.current.Ids;
      if (!ids || !ids.length) {
        this.pluginInstance.ResetSelection();
        return;
      }
      const groupString = (mode === ViewMode.Fade
        ? [{ Color: fadeColor, All: true } as ISelectionArgsGroup]
        : []
      ).concat({ Ids: ids, Select: true, Fit: !!fit });
      this._pluginWrapper.selection.selectElementGroups(
        groupString,
        mode === ViewMode.Hide ? SelectionMode.Only : SelectionMode.All
      );

      if (mode === ViewMode.Clip) this._pluginWrapper.clipping.clip(ids);
      else this._pluginWrapper.clipping.reset();
    }
  }

  showFileDialog() {
    this._ensureInitialize();
    return this._getLocalFileInformation();
  }

  private _getLocalFileInformation(): IOpenFileDialogResult[] {
    return this._pluginWrapper.openFileDialogShow({
      isMultiSelect: false,
      filters: [{ name: '*.p3db', mask: '*.p3db' }]
    });
  }

  async loadFilesAsync(files: IOpenFileDialogResult[], mode: LoadFileMode) {
    this._ensureInitialize();
    let content: ILoadModelInfo[];

    if (files) {
      content = files.map(x => {
        return {
          Name: x.name,
          URL: x.path,
          Size: x.size
        } as ILoadModelInfo;
      });
      switch (mode) {
        case LoadFileMode.Load:
          await this._pluginWrapper.scene.loadFromFile(
            content[0].URL,
            P3DBSceneLoadMode.Npl_File_Open
          );
          this._showPlugin(this.$plugin as HTMLObjectElement);
          break;
        case LoadFileMode.Add:
          await this._pluginWrapper.scene.loadFromFile(
            content[0].URL,
            P3DBSceneLoadMode.Npl_File_Insert
          );
          this._showPlugin(this.$plugin as HTMLObjectElement);
          break;
        case LoadFileMode.Remove:
          // this.pluginInstance.scene.removeFiles(content);
          break;
      }
    } else {
      this.pluginInstance.SceneClear();
    }
  }

  getFiles() {
    return this.pluginInstance.SceneGetFiles();
  }

  clearScene() {
    this._ensureInitialize();
    this._pluginWrapper.scene.clear();
  }

  /**Выставляет выделенные элменты по центру сцены */
  centerViewOnSelected() {
    this.pluginInstance.CenterViewOnSelected();
  }

  private _ensureInitialize() {
    if (this._pluginWrapper.plugin && this._initialize) return;
    throw new Error('Not initialized');
  }

  private _toggleMenuHandler() {
    this.toggleGUI();
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
    if (this._pluginWrapper && this._initialize) {
      this._pluginWrapper.dispose();
    }
  }
}

enum ViewMode {
  All = 0,
  Hide = 1,
  Fade = 2,
  Clip = 3
}

interface IViewer3DModel {
  Id: number;
  Name: string;
  Ids: number[];
}

export enum LoadFileMode {
  Load = 1,
  Add = 2,
  Remove = 3
}

export enum InitializationState {
  Uninitialized = 0,
  Initializing = 1,
  Initialized = 2,
  Unavailable = 3,
  LicenceFailed = 4,
  LicenceExpired = 5,
  PluginIncompatible = 6
}

type ResolveOnlyDeferred = Pick<Deferred<void>, 'promise' | 'resolve'>;

interface ILogger {
  warn(message: string): void;
}

export enum LoadingState {
  Empty = 0,
  Loading = 1,
  Loaded = 2,
  Failed = 3
}

interface ILoadingProcessState {
  state: P3dbLoadingState;
  error?: string;
  progress: number;
}
