import { SharedModule } from './../Shared/shared.module';
import { Viewer3dFileListComponent } from './components/viewer3d-file-list/viewer3d-file-list.component';
import { Viewer3dToolboxComponent } from './components/viewer3d-toolbox/viewer3d-toolbox.component';
import { MaterialModule } from '../../apps/neosintez-client/src/app/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModelsComponent } from './components/models-section/models.component';
import { Viewer3dComponent } from './components/viewer3d/viewer3d.component';
import { ModelsTreeComponent } from './components/models-tree/models-tree.component';

@NgModule({
  imports: [CommonModule, SharedModule, MaterialModule],
  declarations: [
    ModelsComponent,
    Viewer3dComponent,
    Viewer3dToolboxComponent,
    ModelsTreeComponent,
    Viewer3dFileListComponent
  ]
})
export class ModelsModule {}
