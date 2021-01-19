import { IP3DBPluginAuthorizationOptions } from './../../types/wrapper/p3dbplugin-wrapper.types';
import { Injectable } from '@angular/core';
import { NeosyntezContextService } from 'libs/Shared/services/neosyntez-context.service';

@Injectable({
  providedIn: 'root'
})
export class P3DBPluginAuthService {
  constructor(private readonly _neosyntezContext: NeosyntezContextService) {}

  getAuthContext(): IP3DBPluginAuthorizationOptions | undefined {
    const nsContext = this._neosyntezContext.get();
    if (nsContext && nsContext.access_token) {
      return {
        scheme: 'Bearer',
        token: nsContext.access_token
      };
    }
  }
}
