import { RouterModule } from '@angular/router';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { MainMenuComponent } from './components/main-menu/main-menu.component';
import { MaterialModule } from './material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

const components = [
  HomeComponent,
  MainMenuComponent,
  UserProfileComponent,
  PageNotFoundComponent
];

/**Компоненты приложения */
@NgModule({
  imports: [CommonModule, MaterialModule, RouterModule],
  exports: components,
  declarations: components
})
export class AppComponentsModule {

}
