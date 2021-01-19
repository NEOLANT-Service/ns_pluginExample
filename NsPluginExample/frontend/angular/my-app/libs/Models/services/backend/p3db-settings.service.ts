import { NeosyntezHostService } from './../../../Shared/services/neosyntez-host.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**Сервис для работы с настроками плагина */
@Injectable({
  providedIn: 'root'
})
export class P3DBSettingsService {
  constructor(
    private readonly _httpClient: HttpClient,
    private readonly _neosyntezHost:NeosyntezHostService
  ) {}

  /**Вернет настройки для плагина */
  fetch() {
    let endpoint: string=this._neosyntezHost.api+"/settings/plugin3d";
    return this._httpClient.get<IP3DBPluginSettings>(endpoint);
  }
}

export interface IP3DBPluginSettings {
  Version: string;
  Debug?: boolean;
  ContributionCullingThreshold?: number;
  License?: string;
}
