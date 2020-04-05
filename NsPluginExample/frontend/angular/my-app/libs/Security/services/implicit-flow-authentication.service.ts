import { AuthenticationService } from './authentication.service';
import { ConfigSnapshotService } from '../../Shared/services/config-snapshot.service';
import { CryptoService } from './crypto.service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { WindowService } from 'libs/Shared/services/window.service';
import { Deferred } from 'libs/Shared/classes/deferred';
import { Identity } from '../types/identity';
import { OAuthError } from '../types/oauth-error';

@Injectable({
  providedIn: 'root'
})
export class ImplicitFlowAuthenticationService extends AuthenticationService {
  constructor(
    private readonly http: HttpClient,
    private config: ConfigSnapshotService,
    private readonly windowService: WindowService,
    private readonly cryptoService: CryptoService
  ) {
    super();
    this._init();
  }

  private _init() {
    this.windowService.nativeWindow.addEventListener(
      'message',
      this.onConnectResult.bind(this),
      false
    );

    this._authenticated.subscribe(
      () =>
        this._context && this._context.expires < Date.now() && this.disconnect()
    );
  }

  private request?: IAuthRequest;

  connect(): [string, Promise<void>] {
    if (this.request)
      return ['', Promise.reject('auth request already been sent')];

    this.request = {
      state: this.cryptoService.getRandomKey(),
      defer: new Deferred<void>()
    };

    this.endpoints = {
      token: this.config.endpoint + '/connect/authorize',
      userinfo: this.config.endpoint + '/connect/userinfo'
    };

    const url = `${this.endpoints.token}?${new HttpParams({
      fromObject: {
        response_type: 'token id_token',
        client_id: this.config.clientId,
        redirect_uri: `${location.origin}/oauth2-redirect.html`,
        scope: 'ns openid profile',
        nonce: this.cryptoService.getRandomKey(),
        state: this.request.state
      }
    })}`;

    return [url, this.request.defer.promise];
  }

  private async onConnectResult(e: MessageEvent) {
    const result = this.getResult(e, this.request && this.request.state);
    if (!result) return;

    const defer = this.request!.defer;
    this.request = undefined;

    if (this.isOAuthError(result)) {
      this.context = undefined;
      defer.reject(result);
    } else {
      // TODO: validate token and it nonce

      let identity: Identity;
      try {
        identity = await this.getIdentity(result);
      } catch (ex) {
        this.context = undefined;

        defer.reject(ex);
        return;
      }

      const expires = Date.now() + +result.expires_in * 1000;

      defer.resolve();
      this.context = { result: result, identity, expires };
    }
  }

  disconnect() {
    this.context = undefined;

    // TODO: end_session_endpoint?
    alert(
      'Вы будете перенаправлены на сайт Неосинтез.\n Далее нажмите "Выход" и закройте вкладку.'
    );
    this.windowService.nativeWindow.open(this.config.endpoint);
  }

  isOAuthError(i: any): i is OAuthError {
    return i && 'error' in i && 'error_description' in i;
  }

  private async getIdentity(result: OAuthTokenResult) {
    let options = { headers: this.makeAuthHeader(result) };
    let info = await this.http
      .get<OAuthUserInfo>(this.endpoints.userinfo, options)
      .toPromise();

    return {
      id: info.name,
      name: info.name,
      roles: typeof info.role === 'string' ? [info.role] : info.role
    } as Identity;
  }

  private getResult(e: MessageEvent, state?: string) {
    if (state && e.origin === location.origin && typeof e.data === 'string') {
      let result = e.data.split('&').reduce(
        (r, i) => {
          let [k, v] = i.split('=');
          return (r[k] = decodeURIComponent(v)), r;
        },
        {} as any
      ) as OAuthTokenResult | OAuthError;

      if (result.state === state) return result;
    }
    return undefined;
  }
}

interface OAuthTokenResult {
  token_type: 'Bearer';
  access_token: string;
  id_token: string;
  expires_in: string;
  state: string;
}

interface OAuthUserInfo {
  sub: string;
  name: string;
  role: string | string[];
}

interface IAuthRequest {
  state: string;
  defer: Deferred<void>;
}
