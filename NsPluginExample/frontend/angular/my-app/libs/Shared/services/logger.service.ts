import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {
  error(message: string, ...params: any[]) {
    console.error(message, params);
  }

  warning(message: string, ...params: any[]) {
    console.warn(message, params);
  }

  log(message: string, ...params: any[]) {
    console.log(message, params);
  }
}
