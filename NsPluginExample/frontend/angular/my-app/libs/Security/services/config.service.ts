import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SecurityConfigService {
  endpoint: string = 'http://test.vmdev.n.srv';
  clientId: string = 'iframe_client';
}
