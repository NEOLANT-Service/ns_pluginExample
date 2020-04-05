import { AuthenticationService } from './authentication.service';
import { NeosintezContextService } from './../../../apps/neosintez-client/src/app/services/neosintez-context.service';
import { ConfigSnapshotService } from 'libs/Shared/services/config-snapshot.service';
import { Injectable } from '@angular/core';
import { OAuthError } from '../types/oauth-error';
import { Identity } from '../types/identity';

@Injectable({
  providedIn: 'root'
})
export class AccessTokenAuthenticationService extends AuthenticationService {
  constructor(
    private readonly config: ConfigSnapshotService,
    private readonly neosintezContext: NeosintezContextService
  ) {
    super();
  }

  connect(): [string, Promise<void>] {
    const call_context = this.neosintezContext.get();
    const token = this._parseToken(call_context.access_token);
    this.context = {
      result: {
        token_type: 'Bearer',
        access_token: call_context.access_token
      },
      identity: new Identity(token.payload.sub, token.payload.name, token
        .payload.role as string[]),
      expires: new Date(token.payload.auth_time).getUTCDate()
    };
    return undefined;
  }

  disconnect() {
    this.context = null;
  }

  isOAuthError(i: any): i is OAuthError {
    return i && 'error' in i && 'error_description' in i;
  }

  private _parseToken(accessToken: string): JWTToken {
    const parts = accessToken.split('.');
    const token: JWTToken = {
      header: this.decodePart(parts[0]),
      payload: this.decodePart(parts[1]),
      signature: parts[2]
    };
    return token;
  }

  private decodePart(part: string) {
    return JSON.parse(atob(part));
  }
}

interface JWTToken {
  header: JWTTokenHeader;
  payload: JWTTokenPayload;
  signature?: string;
}

interface JWTTokenHeader {
  alg: string;
  typ?: string;
  cty?: string;
  jku?: string;
  jwk?: string;
  kid?: string;
  x5u?: string;
  x5c?: string[];
  crit?: string;
}

interface JWTTokenPayload {
  iss: string;
  sub: string;
  aud: string[];
  exp: number;
  nbf: number;
  jti: string;
  iat: string;
  role: string | string[];
  preferred_username: string;
  name: string;
  idp: string;
  amr: string;
  auth_time: number;
}
