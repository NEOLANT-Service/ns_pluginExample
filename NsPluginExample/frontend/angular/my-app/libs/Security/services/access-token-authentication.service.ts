import { AuthenticationService } from './authentication.service';
import { NeosyntezContextService } from '../../Shared/services/neosyntez-context.service';
import { ConfigSnapshotService } from 'libs/Shared/services/config-snapshot.service';
import { Injectable } from '@angular/core';
import { OAuthError } from '../types/oauth-error';
import { Identity } from '../types/identity';
import { JwtTokenParserService } from './jwt-token-parser.service';

@Injectable({
  providedIn: 'root'
})
export class AccessTokenAuthenticationService extends AuthenticationService {
  constructor(
    private readonly _config: ConfigSnapshotService,
    private readonly _neosintezContext: NeosyntezContextService,
    private readonly _jwtTokenParser: JwtTokenParserService
  ) {
    super();
  }

  connect(): [string, Promise<void>] {
    const call_context = this._neosintezContext.get();
    const token = this._jwtTokenParser.parse(call_context.access_token);
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
}
