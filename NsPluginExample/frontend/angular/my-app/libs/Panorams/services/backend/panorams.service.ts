import { IPanoram } from './panorams.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigSnapshotService } from 'libs/Shared/services/config-snapshot.service';

@Injectable({
  providedIn: 'root'
})
export class PanoramsService {
  constructor(
    private readonly http: HttpClient,
    private readonly config: ConfigSnapshotService
  ) {}
  /**Вернет список панорам */
  getAll() {
    const endpoint = this.config.endpoint + '/api/pano';
    return this.http.get<IPanoram[]>(endpoint);
  }

  /**Вернет дополнительную информацию по панораме */
  get(tourId: string) {
    const endpoint = this.config.endpoint + `/api/pano/${tourId}`;
    return this.http.get(endpoint);
  }

  getStructure() {
    const endpoint = this.config.endpoint + '/api/pano';
    return this.http.get(endpoint);
  }

  getViewURL(panoram: IPanoram) {
    return (
      this.config.endpoint +
      `/api/pano/${panoram.Id}/content//${panoram.Entry}`
    );
  }
}

export interface IPanoram {
  Id: string;
  Name: string;
  Description: string;
  Entry: string;
}
