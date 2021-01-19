import { ConfigSnapshotService } from './../config-snapshot.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';

/**Сервис для получения настроек приложения*/
@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  constructor(
    private readonly _http: HttpClient,
    private readonly _snapshot: ConfigSnapshotService
  ) {}

  /**Вернет настройки */
  fetch() {
    return this._http
      .get<IAppConfig>('/api/settings')
      .pipe(
        map(x => {
          return x;
        }),
        catchError(ex => {
          const config: IAppConfig = {
            neosyntezClient: {
              authType: AppAuthType.AccessToken
            }
          };
          return of(config);
        })
      )
      .pipe(
        map(x => {
          this._snapshot.set(x);
          return x;
        })
      );
  }
}

export interface IAppConfig {
  neosyntezClient: INeosyntezClientConfig;
}

export interface INeosyntezClientConfig {
  instance?: string;
  authType: AppAuthType;
  auth?: {
    clientId: string;
  };
}

export enum AppAuthType {
  None = 0,
  AccessCode = 1,
  ImplicitFlow = 2,
  AccessToken = 3
}
