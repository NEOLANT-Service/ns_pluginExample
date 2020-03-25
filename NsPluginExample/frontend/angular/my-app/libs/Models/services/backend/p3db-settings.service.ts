import { ConfigSnapshotService } from './../../../Shared/services/config-snapshot.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**Сервис для работы с настроками плагина */
@Injectable({
  providedIn: 'root'
})
export class P3DBSettingsService {
  constructor(
    private readonly httpClient: HttpClient,
    private readonly config: ConfigSnapshotService
  ) {}

  /**Вернет настройки для плагина */
  fetch() {
    return this.httpClient.get<IP3DBPluginSettings>(
      this.config.endpoint + '/api/3d/settings'
    );
  }
}

export interface IP3DBPluginSettings {
  Version: string;
  Debug?: boolean;
  ContributionCullingThreshold?: number;
}
