import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PanoramsService {
  constructor(private http: HttpClient) {

  }
  /**Вернет список панорам */
  getAll() {
    return this.http.get<IPanoram[]>('/api/panorams');
  }

  /**Вернет дополнительную информацию по панораме */
  get(tourId: string) {
    return this.http.get(`/api/panorams/${tourId}`)
  }

  getStructure() {
    return this.http.get('/api/panorams');
  }

  getContent() {

  }
}

export interface IPanoram {
  Id: string;
  Name: string;
  Description: string;
  Entry: string;
}
