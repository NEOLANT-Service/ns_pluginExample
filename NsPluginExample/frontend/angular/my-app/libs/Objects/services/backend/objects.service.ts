import { NeosyntezHostService } from './../../../Shared/services/neosyntez-host.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { guid } from 'apps/neosintez-client/src/app/shared/types';

@Injectable({ providedIn: 'root' })
export class NsObjectsService {
  constructor(
    private readonly _http: HttpClient,
    private readonly _host: NeosyntezHostService
  ) {}

  fetch(id: guid) {
    return this._http.get(`${this._host.api}/objects/${id}`);
  }
}

export interface INsObject {
  Attributes: Record<guid, any>;
}
