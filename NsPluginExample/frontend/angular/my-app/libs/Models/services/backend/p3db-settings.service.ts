import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

/**Сервис для работы с настроками плагина */
@Injectable({
  providedIn: 'root'
})
export class P3DBSettingsService {
  constructor(@Inject(HttpClient) private httpClient: HttpClient) {
  }

  /**Вернет настройки для плагина */
  fetch() {
    return this.httpClient.get<IP3DBPluginSettings>('/api/3d/settings');
  }
}

export interface IP3DBPluginSettings {
  Version: string;
  Debug?: boolean;
  ContributionCullingThreshold?: number;
}
