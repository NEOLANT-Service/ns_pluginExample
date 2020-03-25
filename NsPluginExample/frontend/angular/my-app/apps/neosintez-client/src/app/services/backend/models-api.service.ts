import { ConfigSnapshotService } from 'libs/Shared/services/config-snapshot.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { int, guid } from '../../shared/types';
import { WindowService } from 'libs/Shared/services/window.service';

@Injectable()
export class ModelsApiService {
  constructor(
    private readonly httpClient: HttpClient,
    private readonly windowService: WindowService,
    private readonly config: ConfigSnapshotService
  ) {}

  /**Получение контента */
  getContent(modelId: int) {
    const location = this.windowService.nativeWindow.location;
    const endpoint = this.config.endpoint + `/api/models/${modelId}/content`;
    return this.httpClient.get<IModelContent[]>(endpoint).pipe(
      map(response => {
        return response.map(x => {
          const endpoint =
            this.config.endpoint + `/api/models/${modelId}/content/${x.Id}`;
          //`${location.protocol}//${location.host}/api/models/${modelId}/content/${x.Id}`
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
