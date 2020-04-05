import { ConfigSnapshotService } from './../../../Shared/services/config-snapshot.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppAuthType } from 'libs/Shared/services/backend/config.service';
import { map } from 'rxjs/internal/operators/map';

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
    let endpoint: string;
    if (this.config.authType === AppAuthType.ImplicitFlow)
      endpoint = this.config.endpoint + '/api/settings/plugin3d';
    else endpoint = '/api/3d/settings';
    return this.httpClient.get<IP3DBPluginSettings>(endpoint).pipe(
      map(x => {
        if (this.config.authType === AppAuthType.AccessCode) {
          x.LicenseUrl = '/api/3d/licence/.lic';
        } else {
          x.LicenseUrl = this.config.endpoint + '/3d/.lic';
        }
        return x;
      })
    );
  }
}

export interface IP3DBPluginSettings {
  Version: string;
  Debug?: boolean;
  ContributionCullingThreshold?: number;
  LicenseUrl?: string;
}
