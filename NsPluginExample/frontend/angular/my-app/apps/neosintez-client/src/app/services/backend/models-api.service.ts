import { NeosyntezHostService } from './../../../../../../libs/Shared/services/neosyntez-host.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { int, guid } from '../../shared/types';

@Injectable()
export class ModelsApiService {
  constructor(
    private readonly httpClient: HttpClient,
    private readonly _host: NeosyntezHostService
  ) {}

  /**Получение контента */
  getContent(modelId: int) {
    const endpoint = this._host.api + `/models/${modelId}/content`;
    return this.httpClient.get<IModelContent[]>(endpoint).pipe(
      map(response => {
        return response.map(x => {
          const endpoint =
          this._host.apiExtended + `/content/${x.Id}`;
          return {
            Name: x.Name,
            Size: x.Size,
            URL: endpoint
          };
        });
      })
    );
  }
}

export interface IModelContent {
  MediaType: string;
  Extension: string;
  Hash: string;
  Version: int;
  Size: int;
  Id: guid;
  Name: string;
}
