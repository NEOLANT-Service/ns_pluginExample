import { P3DBPluginAuthService } from './services/p3dbplugin/p3dbplugin-auth.service';
import { ModelExampleComponent } from './components/model-example/model-example.component';
import { SharedModule } from './../Shared/shared.module';
import { Viewer3dFileListComponent } from './components/viewer3d-file-list/viewer3d-file-list.component';
import { Viewer3dToolboxComponent } from './components/viewer3d-toolbox/viewer3d-toolbox.component';
import { MaterialModule } from '../../apps/neosintez-client/src/app/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModelsComponent } from './components/models-section/models.component';
import { Viewer3dComponent } from './components/viewer3d/viewer3d.component';
import { ModelsTreeComponent } from './components/models-tree/models-tree.component';
import {
  p3dbInstanceCacheFactory,
  P3DBInstanceCacheType,
  P3DBPluginInstanceCacheService
} from './services/cache/p3db-instance-cache.factory';
import { WINDOW } from '../Shared/tokens/shareds.token';

@NgModule({
  imports: [CommonModule, SharedModule, MaterialModule],
  declarations: [
    ModelsComponent,
    Viewer3dComponent,
    Viewer3dToolboxComponent,
    ModelsTreeComponent,
    Viewer3dFileListComponent,
    ModelExampleComponent
  ],
  providers: [
    {
      provide: P3DBPluginInstanceCacheService,
      useFactory: p3dbInstanceCacheFactory(P3DBInstanceCacheType.Limbo),
      deps: [WINDOW]
    },
    P3DBPluginAuthService
  ]
})
export class ModelsModule {}
