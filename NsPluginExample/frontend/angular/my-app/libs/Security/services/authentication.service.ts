import { Injectable } from '@angular/core';
import { OAuthError } from '../types/oauth-error';
import { Identity } from '../types/identity';
import { BehaviorSubject, Observable } from 'rxjs';
import { distinctUntilChanged } from 'rxjs/operators';
import { IAuthEndpoints } from '../types/auth-endpoints';

const authContextName = 'authContext';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor() {}

  protected _authenticated = new BehaviorSubject<boolean>(false);
  get authenticated(): Observable<boolean> {
    return this._authenticated.pipe(distinctUntilChanged());
  }

  get isAuthenticated() {
    return !!this.identity;
  }

  get identity() {
    return this.context ? this.context.identity : undefined;
  }

  protected _context?: {
    readonly result: any;
    readonly identity: Identity;
    readonly expires: number;
  };
  protected get context() {
    if (!this._context) {
      let c = sessionStorage.getItem(authContextName);
      if (c) this._context = JSON.parse(c);

      this._authenticated.next(!!this._context);
    }
    return this._context;
  }
  protected set context(v) {
    if (v) sessionStorage.setItem(authContextName, JSON.stringify(v));
    else sessionStorage.removeItem(authContextName);
    this._context = v;

    this._authenticated.next(this.isAuthenticated);
  }

  protected endpoints: IAuthEndpoints;

  connect(): [string, Promise<void>] {
    return undefined;
  }

  disconnect() {
    this.context = null;
  }

  async getAuthHeader() {
    if (!this.context) throw new Error('AccessToken is not available');

    // TODO: запрашивать новый токен в случае просрочки
    return this.makeAuthHeader(this.context.result);
  }

  protected makeAuthHeader(result: any) {
    return {
      Authorization: `${result.token_type} ${result.access_token}`
    };
  }

  isOAuthError(i: any): i is OAuthError {
    return false;
  }
}
