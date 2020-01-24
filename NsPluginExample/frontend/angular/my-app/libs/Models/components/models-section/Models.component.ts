import { AppEnvironmentService } from './../../../../apps/neosintez-client/src/app/services/app-environment.service';
import { Viewer3dFileListComponent } from './../viewer3d-file-list/viewer3d-file-list.component';
import { Viewer3dComponent, LoadFileMode } from './../viewer3d/viewer3d.component';
import { IToolboxClickEvent } from './../viewer3d-toolbox/viewer3d-toolbox.component';
import { takeUntil } from 'rxjs/operators';
import { Component, OnInit,  OnDestroy, ViewChild } from '@angular/core';
import { P3DBSettingsService } from 'libs/Models/services/backend/p3db-settings.service';
import { Subject } from 'rxjs';
import { P3dbPluginOptions } from '../viewer3d/plugin/plugin-startup-options';
import { MatSidenav } from '@angular/material/sidenav';
import { IModel } from 'libs/Models/services/backend/models.service';
import { DialogResultState } from '../viewer3d/plugin/plugin-intsance';

enum DrawerMode {
  None = 0,
  Tree = 1,
  Files = 2
}

/**Компонент-обертка */
@Component({
  selector: 'app-models',
  templateUrl: './models.component.html',
  styleUrls: ['./models.component.scss']
})
export class ModelsComponent implements OnInit, OnDestroy {
  pluginOptions: P3dbPluginOptions;
  mode: DrawerMode = DrawerMode.None;
  drawerModes = DrawerMode;
  inIFRAME=this.environmentService.inIFRAME;

  private ngUnsubscribe: Subject<void> = new Subject();

  @ViewChild("sidenav", { static: true }) sidenav: MatSidenav;
  @ViewChild("viewer3d", { static: true }) viewer3d: Viewer3dComponent;
  @ViewChild("viewer3dfiles", { static: true }) viewer3dfiles: Viewer3dFileListComponent;

  constructor(
    private p3dbSettingsService: P3DBSettingsService,
    private environmentService: AppEnvironmentService
  ) { }

  ngOnInit() {
    this.fetch();
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
    this.viewer3d = null;
  }

  commandClickHandler(event: IToolboxClickEvent) {
    let showDialogResult;

    switch (event.button.name) {
      case "tree":
        if (this.mode !== DrawerMode.Tree) {
          this.sidenav.open();
        } else
          this.sidenav.toggle();
        this.mode = DrawerMode.Tree;
        break;
      case "openFiles":
        showDialogResult = this.viewer3d.showFileDialog();
        if (showDialogResult.State === DialogResultState.Success && showDialogResult.Files) {
          this.viewer3d.loadFiles(showDialogResult.Files, LoadFileMode.Load);
        }
        break;
      case "addFiles":
        showDialogResult = this.viewer3d.showFileDialog();
        if (showDialogResult.State === DialogResultState.Success && showDialogResult.Files) {
          this.viewer3d.loadFiles(showDialogResult.Files, LoadFileMode.Add);
        }
        break;
      case "removeFiles":
        if (this.mode !== DrawerMode.Files) {
          this.sidenav.open();
        } else
          this.sidenav.toggle();
        this.mode = DrawerMode.Files;
        const files = this.viewer3d.getFiles();
        this.viewer3dfiles.files = files;
        // showDialogResult = this.viewer3d.showFileDialog();
        // if (showDialogResult.State === DialogResultState.Success && showDialogResult.Files) {
        //   this.viewer3d.loadFiles(showDialogResult.Files, LoadFileMode.Remove);
        // }
        break;
      case "clearScene":
        this.viewer3d.clearScene();
        break;
      case "toggleGUI":
        this.viewer3d.toggleGUI();
        break;
      case "crosshairs":
        this.viewer3d.centerViewOnSelected();
        break;
      case "showAll":
      case "hide":
      case "fade":
      case "clip":
        this.viewer3d.select(event.button.value, false);
        break;
    }
  }

  modelSelectedChangeHandler(event: IModel) {
    this.viewer3d.loadModel(event.Id);
  }

  selectedChangeHandler($event: number[]) {

  }

  private fetch() {
    this.fetchSettings();
  }

  /**Получение настроек для плагина */
  private fetchSettings() {
    this.p3dbSettingsService.fetch()
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        this.pluginOptions = new P3dbPluginOptions(x.ContributionCullingThreshold, x.Debug, x.Version, "/api/3d/licence/.lic");
      })
  }
}
