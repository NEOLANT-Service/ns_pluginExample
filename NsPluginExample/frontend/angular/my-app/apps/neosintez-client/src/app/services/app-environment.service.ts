import { Injectable } from '@angular/core';
import { WindowService } from './window.service';

/** Сервичс  */
@Injectable({
  providedIn: 'root'
})
export class AppEnvironmentService {
  constructor(private windowService: WindowService) {

  }

  /**Запущенно в IFRAME */
  get inIFRAME(): boolean {
    try {
      return this.windowService.nativeWindow.self !== window.top;
    } catch (e) {
      return true;
    }
  }
}
