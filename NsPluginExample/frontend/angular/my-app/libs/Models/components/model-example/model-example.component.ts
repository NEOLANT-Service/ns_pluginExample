import { NsObjectsService } from './../../../Objects/services/backend/objects.service';
import { NeosyntezContextService } from 'libs/Shared/services/neosyntez-context.service';
import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  ViewChild
} from '@angular/core';
import { AppEnvironmentService } from 'apps/neosintez-client/src/app/services/app-environment.service';
import { P3DBSettingsService } from 'libs/Models/services/backend/p3db-settings.service';
import { takeUntil } from 'rxjs/internal/operators/takeUntil';
import { Subject } from 'rxjs/internal/Subject';
import { P3dbPluginOptions } from '../viewer3d/plugin/plugin-startup-options';
import { Viewer3dComponent } from '../viewer3d/viewer3d.component';
import { MatSelectChange } from '@angular/material';

@Component({
  selector: 'app-model-example',
  templateUrl: './model-example.component.html',
  styleUrls: ['./model-example.component.scss']
})
export class ModelExampleComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('viewer3d', { static: true }) viewer3d: Viewer3dComponent;

  pluginOptions: P3dbPluginOptions;
  object: any;

  private ngUnsubscribe: Subject<void> = new Subject();

  constructor(
    private readonly _p3dbSettingsService: P3DBSettingsService,
    private readonly _environmentService: AppEnvironmentService,
    private readonly _neosyntezContext: NeosyntezContextService,
    private readonly _objectsService: NsObjectsService
  ) {}

  ngOnInit() {
    this._fetchSettings();
  }

  ngAfterViewInit() {
    this._fetchObjectData();
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
    this.viewer3d = null;
  }

  selectedChangeHandler() {}

  attributeChangeHandler(change: MatSelectChange) {
    if (change.value) {
      this._loadModel(change.value);
    } else {
      this.viewer3d.clearScene();
    }
  }

  /**Получение настроек для плагина */
  private _fetchSettings() {
    this._p3dbSettingsService
      .fetch()
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        this.pluginOptions = new P3dbPluginOptions(
          x.ContributionCullingThreshold,
          x.Debug,
          x.Version,
          x.License
        );
      });
  }

  private _fetchObjectData() {
    const objectId = this._neosyntezContext.get().objectId;
    this._objectsService
      .fetch(objectId)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(x => {
        this.object = x;
      });
  }

  private async _loadModel(id: number) {
    await this.viewer3d.loadModel(id);
  }
}
