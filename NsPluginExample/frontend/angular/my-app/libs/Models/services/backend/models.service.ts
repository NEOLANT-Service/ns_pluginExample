import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ModelsService {

  constructor(@Inject(HttpClient) private http: HttpClient) { }

  /**Вернет модели */
  fetchModels(id?: number) {
    return this.http.get<IModel[]>(`/api/models/${id ? id : ''}`);
  }
}

export interface IModel {
  Children: IModel[],
  HasChildren?: boolean;
  Level?: number;
  Icon: string;
  Type?: NodeType;
  Id: number;
  Name: string;
  Description: string;
}

export enum NodeType{
  None=0,
  System=1,
  Folder=2,
  Object=3,
  Report=4,
  Model=5,
  Sensor=6
}
