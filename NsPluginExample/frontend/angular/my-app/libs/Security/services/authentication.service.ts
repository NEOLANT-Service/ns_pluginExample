import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { distinctUntilChanged } from 'rxjs/operators';
import { Logger } from '../../shared/logger.service';
import { Deferred } from '../../shared/deferred';
import { config } from '../../ns.config';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _authenticated = new BehaviorSubject<boolean>(false);
  get authenticated(): Observable<boolean> {
    return this._authenticated.pipe(distinctUntilChanged());
  }

  get isAuthenticated() {
    return !!this.identity;
  }

  get identity() {
    return this.context ? this.context.identity : undefined;
  }

  //#region context:!!! прям очень временно
  private _context?: {
    readonly result: OAuthTokenResult;
    readonly identity: Identity;
    readonly expires: number;
  };
  private get context() {
    if (!this._context) {
      let c = sessionStorage.getItem('authContext');
      if (c) this._context = JSON.parse(c);

      this._authenticated.next(!!this._context);
    }
    return this._context;
  }
  private set context(v) {
    if (v) sessionStorage.setItem('authContext', JSON.stringify(v));
    else sessionStorage.removeItem('authContext');
    this._context = v;

    this._authenticated.next(this.isAuthenticated);
  }
  //#endregion

  constructor(private http: HttpClient, private logger: Logger) {
    window.addEventListener('message', this.onConnectResult.bind(this), false);

    this._authenticated.subscribe(
      () =>
        this._context && this._context.expires < Date.now() && this.disconnect()
    );
  }

  //#region connect/disconnect

  private request?: {
    state: string;
    defer: Deferred<void>;
  };

  connect(): [string, Promise<void>] {
    if (this.request)
      return ['', Promise.reject('auth request already been sent')];

    this.request = {
      state: this.getRandomKey(),
      defer: new Deferred<void>()
    };

    let url = `${endpoints.token}?${new HttpParams({
      fromObject: {
        response_type: 'token id_token',
        client_id: config.clientId,
        redirect_uri: `${location.origin}/oauth2-redirect.html`,
        scope: 'ns openid profile',
        nonce: this.getRandomKey(),
        state: this.request.state
      }
    })}`;

    return [url, this.request.defer.promise];
  }

  private async onConnectResult(e: MessageEvent) {
    let result = this.getResult(e, this.request && this.request.state);
    if (!result) return;

    let defer = this.request!.defer;
    this.request = undefined;

    if (isOAuthError(result)) {
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

      let expires = Date.now() + +result.expires_in * 1000;

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
    window.open(config.endpoint);
  }

  //#endregion

  //#region support

  /**
   *  internal use only
   */
  async getAuthHeader() {
    if (!this.context) throw new Error('AccessToken is not available');

    // TODO: запрашивать новый токен в случае просрочки

    return this.makeAuthHeader(this.context.result);
  }

  private makeAuthHeader(result: OAuthTokenResult) {
    return {
      Authorization: `${result.token_type} ${result.access_token}`
    };
  }

  private async getIdentity(result: OAuthTokenResult) {
    let options = { headers: this.makeAuthHeader(result) };
    let info = await this.http
      .get<OAuthUserInfo>(endpoints.userinfo, options)
      .toPromise();

    return {
      id: info.name,
      name: info.name,
      roles: typeof info.role == 'string' ? [info.role] : info.role
    } as Identity;
  }

  private getRandomKey() {
    let crypto = window.crypto || (<any>window).msCrypto;

    let buf = new Uint8Array(10);
    crypto.getRandomValues(buf);
    return btoa(Array.from(buf).join(''));
  }

  private getResult(e: MessageEvent, state?: string) {
    if (state && e.origin === location.origin && typeof e.data == 'string') {
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

  //#endregion
}

// TODO: accessToken`ы храним в памяти, refresh в sessionStorage и пингпонг нужен только при перезапуске браузера на выписывание нового accessToken

const endpoints = {
  token: config.endpoint + '/connect/authorize',
  userinfo: config.endpoint + '/connect/userinfo'
};

interface Identity {
  readonly id: string;
  readonly name: string;
  readonly roles: string[];
  // privileges
  // permissions
}

//#region OAuth*

interface OAuthTokenResult {
  token_type: 'Bearer';
  access_token: string;
  id_token: string;
  expires_in: string;
  state: string;
}

function isOAuthTokenResult(i: any): i is OAuthTokenResult {
  return i && 'token_type' in i && 'access_token' in i;
}

interface OAuthError {
  error: string;
  error_description: string;
  state: string;
}

export function isOAuthError(i: any): i is OAuthError {
  return i && 'error' in i && 'error_description' in i;
}

interface OAuthUserInfo {
  sub: string;
  name: string;
  role: string | string[];
}

//#endregion
