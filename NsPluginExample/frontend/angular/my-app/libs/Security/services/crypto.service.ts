import { Injectable } from '@angular/core';
import { WindowService } from 'libs/Shared/services/window.service';

@Injectable({
  providedIn: 'root'
})
export class CryptoService {
  constructor(private readonly windowService: WindowService) {}

  getRandomKey():string {
    const window = this.windowService.nativeWindow;
    const crypto = window.crypto || (<any>window).msCrypto;

    const buf = new Uint8Array(10);
    crypto.getRandomValues(buf);
    return btoa(Array.from(buf).join(''));
  }
}
