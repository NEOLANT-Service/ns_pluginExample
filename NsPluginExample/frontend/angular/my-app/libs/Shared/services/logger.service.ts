import { Injectable } from '@angular/core';
import { WindowService } from './window.service';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {
  private window: Window;

  constructor(private windowService: WindowService) {
    this.window = this.windowService.nativeWindow;
  }

  error(message: string, ...params: any[]) {
    this.window.console.error(message, params);
  }

  warning(message: string, ...params: any[]) {
    this.window.console.warn(message, params);
  }

  log(message: string, ...params: any[]) {
    this.window.console.log(message, params);
  }
}
