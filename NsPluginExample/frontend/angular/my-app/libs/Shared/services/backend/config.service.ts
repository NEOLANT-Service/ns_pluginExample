import { ConfigSnapshotService } from './../config-snapshot.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  constructor(
    private readonly http: HttpClient,
    private readonly snapshot: ConfigSnapshotService
  ) {}

  fetch() {
    return this.http.get<IAppConfig>('/api/settings').pipe(
      map(x => {
        this.snapshot.set(x);
        return x;
      })
    );
  }
}

export interface IAppConfig {
  neosyntezClient: INeosyntezClientConfig;
}

export interface INeosyntezClientConfig {
  instance: string;
  authType: AppAuthType;
  auth: {
    clientId: string;
  };
}

export enum AppAuthType {
  None = 0,
  Code = 1,
  Token = 2
}
