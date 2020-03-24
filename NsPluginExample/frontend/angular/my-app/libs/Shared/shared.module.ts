import { NgModule } from '@angular/core';
import { LoggerService } from './services/logger.service';
import { WindowService } from './services/window.service';

@NgModule({
  providers: [WindowService, LoggerService]
})
export class SharedModule {}
