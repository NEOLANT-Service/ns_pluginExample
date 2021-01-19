import { ImplicitFlowAuthenticationService } from './services/implicit-flow-authentication.service';
import { LoginComponent } from './components/login/login.component';
import { CryptoService } from './services/crypto.service';
import { SharedModule } from './../Shared/shared.module';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationService } from './services/authentication.service';
import { AccessTokenInterceptor } from './services/access-token.interceptor';
import { CommonModule } from '@angular/common';
import { AccessTokenAuthenticationService } from './services/access-token-authentication.service';
import { JwtTokenParserService } from './services/jwt-token-parser.service';

@NgModule({
  imports: [SharedModule, CommonModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AccessTokenInterceptor,
      multi: true
    },
    ImplicitFlowAuthenticationService,
    AccessTokenAuthenticationService,
    AuthenticationService,
    CryptoService,
    JwtTokenParserService
  ],
  declarations: [LoginComponent],
  exports: [LoginComponent]
})
export class SecurityModule {}
