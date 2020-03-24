import { SharedModule } from './../../../../libs/Shared/shared.module';
import { AvailableGuard } from './services/available.guard';
import { AppEnvironmentService } from './services/app-environment.service';
import { PanoramsComponent } from '../../../../libs/Panorams/components/panorams-section/panorams.component';
import { PanoramsModule } from './../../../../libs/Panorams/Panorams.module';
import { ModelsModule } from '../../../../libs/Models/models.module';
import { ObjectsModule } from './../../../../libs/Objects/Objects.module';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { MaterialModule } from './material.module';
import { HomeComponent } from './components/home/home.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ModelsApiService } from './services/backend/models-api.service';
import { CommonModule } from '@angular/common';
import { AppComponentsModule } from './app-components.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ObjectsComponent } from 'libs/Objects/components/objects-section/Objects.component';
import { ModelsComponent } from 'libs/Models/components/models-section/models.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AvailableGuard] },
  { path: 'profile', component: UserProfileComponent },
  { path: 'objects', component: ObjectsComponent },
  { path: 'models', component: ModelsComponent },
  { path: 'panorams', component: PanoramsComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    AppComponentsModule,
    MaterialModule,
    CommonModule,
    HttpClientModule,
    ObjectsModule,
    ModelsModule,
    PanoramsModule,
    SharedModule
  ],
  providers: [
    ModelsApiService,
    HttpClient,
    AppEnvironmentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
