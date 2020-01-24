import { WindowService } from './../window.service';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { int, guid } from '../../shared/types';

export interface IModelContent {
  MediaType: string;
  Extension: string;
  Hash: string;
  Version: int;
  Size: int;
  Id: guid;
  Name: string;
}

@Injectable()
export class ModelsApiService {
  constructor(private httpClient: HttpClient, private windowService: WindowService) {

  }

  /**Получение контента */
  getContent(modelId: int) {
    const location = this.windowService.nativeWindow.location;
    return this.httpClient.get<IModelContent[]>(`/api/models/${modelId}/content`)
      .pipe(map(response => {
        return response.map(x => {
          return {
            Name: x.Name,
            Size: x.Size,
            URL: `${location.protocol}//${location.host}/api/models/${modelId}/content/${x.Id}`
          }
        })
      }))
  }
}

