import { AppAuthType } from './backend/config.service';
import { NeosyntezContextService } from 'libs/Shared/services/neosyntez-context.service';
import { ConfigSnapshotService } from './config-snapshot.service';
import { Inject, Injectable } from '@angular/core';

/**Вспомогательный сервис для вычисления адреса инстанса НС для работы с api */
@Injectable({ providedIn: 'root' })
export class NeosyntezHostService {
  constructor(
    @Inject(ConfigSnapshotService)
    private readonly config: ConfigSnapshotService,
    @Inject(NeosyntezContextService)
    private readonly context: NeosyntezContextService
  ) {}

  get host() {
    switch (this.config.authType) {
      case AppAuthType.ImplicitFlow:
      case AppAuthType.AccessToken:
        return this.context.get().url;
      case AppAuthType.AccessCode:
        return this.config.endpoint;
    }
    return undefined;
  }

  get api() {
    return `${this.host}/api`;
  }

  get apiExtended() {
    return this.host ? this.api : `${window.location.protocol}//${window.location.host}/api`;
  }
}
