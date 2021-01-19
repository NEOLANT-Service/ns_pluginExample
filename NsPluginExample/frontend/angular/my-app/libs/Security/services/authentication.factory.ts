import { JwtTokenParserService } from './jwt-token-parser.service';
import { HttpClient } from '@angular/common/http';
import { ConfigSnapshotService } from 'libs/Shared/services/config-snapshot.service';
import { WindowService } from 'libs/Shared/services/window.service';
import { CryptoService } from './crypto.service';
import { NeosyntezContextService } from 'libs/Shared/services/neosyntez-context.service';
import { ImplicitFlowAuthenticationService } from './implicit-flow-authentication.service';
import { AccessTokenAuthenticationService } from './access-token-authentication.service';
import { AppAuthType } from 'libs/Shared/services/backend/config.service';
import { AuthenticationService } from './authentication.service';

let authenticationServiceFactory = (
  httpClient: HttpClient,
  config: ConfigSnapshotService,
  windowService: WindowService,
  cryptoService: CryptoService,
  neosintezContext: NeosyntezContextService,
  jwtTokenParserService:JwtTokenParserService
) => {
  switch (config.authType) {
    case AppAuthType.ImplicitFlow:
      return new ImplicitFlowAuthenticationService(
        httpClient,
        config,
        windowService,
        cryptoService
      );
    case AppAuthType.AccessToken:
      return new AccessTokenAuthenticationService(config, neosintezContext,jwtTokenParserService);
  }
};

export let authenticationServiceProvider = {
  provide: AuthenticationService,
  useFactory: authenticationServiceFactory,
  deps: [
    HttpClient,
    ConfigSnapshotService,
    WindowService,
    CryptoService,
    NeosyntezContextService,
    JwtTokenParserService
  ]
};

