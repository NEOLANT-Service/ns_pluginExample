import { ConfigSnapshotService } from './services/config-snapshot.service';
import { ConfigService } from './services/backend/config.service';
import { NgModule } from '@angular/core';
import { LoggerService } from './services/logger.service';
import { WindowService } from './services/window.service';

@NgModule({
  providers: [
    WindowService,
    LoggerService,
    ConfigService,
    ConfigSnapshotService
  ]
})
export class SharedModule {}

