import { ModelsApiService } from '../../../../apps/neosintez-client/src/app/services/backend/models-api.service';
import { Component, OnInit, ElementRef, AfterViewInit, OnDestroy, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { Viewer3dService } from './viewer3d.service';
import { P3dbPluginInstance, IInitializationErrorEvent, P3dbLoadingState, P3dbInitializationState, ILoadingStateChangedEvent, SelectionMode, ISelectionArgsGroup, ILoadModelInfo, IDialogFile } from './plugin/plugin-intsance';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { _getOptionScrollPosition } from '@angular/material/core';
import { P3dbPluginOptions } from './plugin/plugin-startup-options';


export const fadeColor = "0000000A";

/**Компонент-обертка для работы с плагином P3DB
 *
 * @Input modelId - Идентификатор модели, которую необходимо загрузить в плагин
 * @Input options - Настройки для инициализации плагина
 */
@Component({
  selector: 'app-viewer3d',
  templateUrl: './viewer3d.component.html',
  styleUrls: ['./viewer3d.component.less'],
  providers: [Viewer3dService]
})
export class Viewer3dComponent implements OnInit, AfterViewInit, OnDestroy {
  private current: IViewer3DModel;

  private _modelId: number;
  @Input() set modelId(value: number) {
    this._modelId = value;
    this.current = { Id: value, Ids: [] } as IViewer3DModel;
  }
  get modelId() { return this._modelId; }

  private _options: P3dbPluginOptions;
  /**Опции плагина */
  @Input() set options(value: P3dbPluginOptions) {
    if (!this.isInitialized) {
      this._options = value;
      if (this._options)
        this.initInstance();
    }
  }
  get options() { return this._options; };

  private _viewMode: ViewMode | undefined;
  @Input() set viewMode(value: ViewMode | undefined) {
    this._viewMode = value;
    this.select(this._viewMode, false);
  }
  get viewMode() { return this._viewMode; }

  @Output() selectedChanged = new EventEmitter<number[]>();

  @ViewChild('pluginContainer', { static: true }) protected pluginContainer: ElementRef;

  private pluginInstance: P3dbPluginInstance;
  isSupported: boolean;
  isInitialized: boolean = false;
  pluginError: IInitializationErrorEvent;
  initializationStates = P3dbInitializationState;
  loadingProcessState: ILoadingStateChangedEvent;
  loadingProcessStates = P3dbLoadingState;
  needInstall: boolean = false;
  get isLoading(): boolean {
    return this.pluginInstance && this.pluginInstance.isLoading;
  }

  get hasSelected() {
    return !!this.current.Ids.length;
  }

  private ngUnsubscribe = new Subject<void>();

  constructor(
    private viewer3dService: Viewer3dService,
    private modelsApi: ModelsApiService
  ) { }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
    if (this.pluginInstance && this.isInitialized) {
      this.pluginInstance.destroy();
    }
  }

  ngAfterViewInit() {
    if (this.options) {
      this.initInstance();
    }
  }

  toggleGUI(show?: boolean) {
    if (this.isInitialized) {
      const cache = this.toggleGUI as unknown as {
        show: boolean
      };
      show = show !== undefined ? show : !cache.show;
      this.pluginInstance.ToggleGUI(cache.show = show);
    }
  }

  select(mode: ViewMode, fit: boolean) {
    if (this.pluginInstance && this.isInitialized) {
      const ids = this.current && this.current.Ids;
      if (!ids || !ids.length) {
        this.pluginInstance.resetSelection();
        return;
      }

      this.pluginInstance.selectElements({
        groups: (mode === ViewMode.Fade ? [{ Color: fadeColor, All: true } as ISelectionArgsGroup] : []).concat({ Ids: ids, Select: true, Fit: !!fit }),
        mode: mode === ViewMode.Hide ? SelectionMode.Only : SelectionMode.All
      });

      if (mode === ViewMode.Clip) this.pluginInstance.clip(ids);
      else this.pluginInstance.resetClip();
    }
  }

  showFileDialog() {
    this.ensureInitialize();
    return this.pluginInstance.getLocalFileInformation();
  }

  loadFiles(files: IDialogFile[], mode: LoadFileMode) {
    this.ensureInitialize();
    let content: ILoadModelInfo[];

    if (files) {
      content = files.map(x => {
        return { Name: x.FileName, URL: x.Name, Size: x.Size } as ILoadModelInfo
      })
      switch (mode) {
        case LoadFileMode.Load:
          this.pluginInstance.scene.loadScene(content);
          break;
        case LoadFileMode.Add:
          this.pluginInstance.scene.addFiles(content);
          break;
        case LoadFileMode.Remove:
          this.pluginInstance.scene.removeFiles(content);
          break;
      }
    } else {
      this.pluginInstance.scene.clear();
    }
  }

  getFiles() {
    return this.pluginInstance.scene.fetchFiles();
  }

  clearScene() {
    this.ensureInitialize();
    this.pluginInstance.scene.clear();
  }

  /**загрузка модели
   * @param modelId Идентфикатор модели Неосинтеза
   */
  loadModel(modelId: number) {
    this.ensureInitialize();
    if (!modelId) throw new Error("modelId is missing");
    else {
      this.modelId = modelId;
      this.modelsApi.getContent(modelId).subscribe({
        next: (x) => {
          this.togglePluginContainer(false);
          this.pluginInstance.loadModel(x);
        }
      })
    }
  }

  /**Выставляет выделенные элменты по центру сцены */
  centerViewOnSelected() {
    this.pluginInstance.centerViewOnSelected();
  }

  /**Инициализация экземпляра плагина */
  private initInstance() {
    const self = this;
    if (!this.isInitialized) {
      setTimeout(() => {
        self.togglePluginContainer(false);
        if (self.viewer3dService.browserSupport) {
          self.isSupported = true;
          try {
            self.pluginInstance = self.viewer3dService.getPluginInstance(self.options, 1, self.pluginContainer.nativeElement);
            this.subscribe();
          } catch (ex) {
            this.needInstall = true;
          }
        } else {
          self.isSupported = false;
        }
      })
    }
  }

  /**Пользовательские настройки плагина */
  private customInit() {

    // инициализировать UI
    this.pluginInstance.SetBackgroundColor("FFFFFFFF");

    const commands = {
      1001: {
        name: "scene",
        caption: "Сцена",
        1004: {
          name: "scene_clear",
          caption: "Очистить"
        }
      },
      1002: {
        name: "bycenterview",
        caption: "По центру сцены"
      },
      1003: {
        name: "toggleGUI",
        caption: 'Показать GUI'
      }
    };

    this.pluginInstance.AddContextMenuCommands({
      Group: 'NEOSYNTEZ Examples',
      Commands: Object.entries(commands).map(([id, v]) => ({
        Id: id,
        Name: v.caption
      }))
    });
  }

  /**Подписывание на событие плагина */
  private subscribe() {
    this.pluginInstance.initializationError
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        if (x) {
          this.isInitialized = false;
          this.pluginError = x;
        }
      });

    this.pluginInstance.initializationSuccess
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        if (x) {
          this.pluginError = null;
          this.isInitialized = true;
          this.customInit();
          if (this.modelId) {
            this.loadModel(this.modelId);
          } else {
            this.togglePluginContainer(true);
          }
        }
      });

    this.pluginInstance.loadingStateChanged
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        this.loadingProcessState = x;
        switch (x.state) {
          case P3dbLoadingState.Loaded:
            this.loadingProcessState = null;
            this.togglePluginContainer(true);
            break;
          case P3dbLoadingState.Aborted:
          case P3dbLoadingState.Failed:
            this.loadingProcessState = null;
            break;
        }
      });

    this.pluginInstance.selectedChanged
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        this.selectedChangeHandler(x);
      });

    /**Подписываемся на события контекстного меню плагина */
    this.pluginInstance.contextMenuClick
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        this.customMenuClickHandler(x);
      })
  }

  /**Обработка пользовательского мерю плагина */
  private customMenuClickHandler(command: number) {
    switch (command) {
      case 1002:
        this.pluginInstance.centerViewOnSelected();
        break;
      case 1003:
        this.toggleGUI();
        break;
    }
  }

  /**Обработка выделения элементов на сцене */
  private selectedChangeHandler(selected: number[]) {
    this.current.Ids = selected;
    this.selectedChanged.emit(selected);
  }

  /**Скрыть показать контейнер плагина */
  private togglePluginContainer(show: boolean) {
    if (this.pluginContainer)
      this.pluginContainer.nativeElement.style.visibility = show ? "visible" : "hidden";
  }

  private ensureInitialize() {
    if (this.pluginInstance && this.isInitialized)
      return;
    throw new Error('Not initialized');
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
  Ids: number[]
}

export enum LoadFileMode {
  Load = 1,
  Add = 2,
  Remove = 3
}
