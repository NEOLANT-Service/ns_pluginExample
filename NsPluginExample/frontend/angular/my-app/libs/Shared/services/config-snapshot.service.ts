import { IAppConfig } from './backend/config.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigSnapshotService {
  constructor() {}
  endpoint: string;
  clientId: string;

  set(config: IAppConfig) {
    if (config && config.neosyntezClient) {
      this.endpoint = config.neosyntezClient.instance;
      if (config.neosyntezClient.auth) {
        this.clientId = config.neosyntezClient.auth.clientId;
      }
    }
  }
}
