import { IAppConfig, AppAuthType } from './backend/config.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigSnapshotService {
  constructor() {}
  endpoint: string;
  clientId: string;
  authType: AppAuthType;

  set(config: IAppConfig) {
    if (config && config.neosyntezClient) {
      this.endpoint = config.neosyntezClient.instance;
      this.authType=config.neosyntezClient.authType;
      if (config.neosyntezClient.auth) {
        this.clientId = config.neosyntezClient.auth.clientId;
      }
    }
  }
}
