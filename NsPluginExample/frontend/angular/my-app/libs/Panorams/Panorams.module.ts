import { PanoramViewComponent } from './components/panoram-view/panoram-view.component';
import { PanoramsListComponent } from './components/panorams-list/panorams-list.component';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from './../../apps/neosintez-client/src/app/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanoramsComponent } from './components/panorams-section/panorams.component';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule
  ],
  declarations: [
    PanoramsComponent,
    PanoramsListComponent,
    PanoramViewComponent
  ]
})
export class PanoramsModule { }
