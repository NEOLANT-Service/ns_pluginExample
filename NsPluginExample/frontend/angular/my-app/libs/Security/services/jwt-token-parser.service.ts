import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtTokenParserService {
  parse(accessToken: string): JWTToken {
    if (!accessToken) throw 'Access token is empty or undefined';
    return this._parseToken(accessToken);
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
