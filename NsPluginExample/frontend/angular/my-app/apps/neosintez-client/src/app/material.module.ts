import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatMenuModule } from "@angular/material/menu";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { MatTreeModule } from '@angular/material/tree';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatCardModule } from "@angular/material/card";
import { MatButtonToggleModule } from '@angular/material/button-toggle';

import { FlexLayoutModule } from '@angular/flex-layout';

const modules = [
  MatSidenavModule,
  MatListModule,
  MatTabsModule,
  MatToolbarModule,
  MatMenuModule,
  FlexLayoutModule,
  MatIconModule,
  MatButtonModule,
  MatTreeModule,
  MatProgressBarModule,
  MatCardModule,
  MatButtonToggleModule
]

@NgModule({
  exports: modules
})
export class MaterialModule {

}
