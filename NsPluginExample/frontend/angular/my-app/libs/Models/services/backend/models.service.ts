import { NeosyntezHostService } from './../../../Shared/services/neosyntez-host.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ModelsService {
  constructor(
    private readonly _http: HttpClient,
    private readonly _neosyntezHost: NeosyntezHostService
  ) {}

  /**Вернет модели */
  fetchModels(id?: number) {
    const endpoint = `${this._neosyntezHost.api}/models/${id ? id : ''}`;
    return this._http.get<IModel[]>(endpoint);
  }
}

export interface IModel {
  Children: IModel[];
  HasChildren?: boolean;
  Level?: number;
  Icon: string;
  Type?: NodeType;
  Id: number;
  Name: string;
  Description: string;
}

export enum NodeType {
  None = 0,
  System = 1,
  Folder = 2,
  Object = 3,
  Report = 4,
  Model = 5,
  Sensor = 6
}
