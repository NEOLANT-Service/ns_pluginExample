import { NsObjectsService } from './services/backend/objects.service';
import { MaterialModule } from './../../apps/neosintez-client/src/app/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ObjectsComponent } from './components/objects-section/Objects.component';

@NgModule({
  imports: [CommonModule, MaterialModule],
  declarations: [ObjectsComponent],
  providers: [NsObjectsService]
})
export class ObjectsModule {}
