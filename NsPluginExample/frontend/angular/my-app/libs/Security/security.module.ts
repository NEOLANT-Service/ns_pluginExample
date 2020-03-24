import { LoginComponent } from './components/login/login.component';
import { CryptoService } from './services/crypto.service';
import { SecurityConfigService } from './services/config.service';
import { SharedModule } from './../Shared/shared.module';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationService } from './services/authentication.service';
import { AccessTokenInterceptor } from './services/access-token.interceptor';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [SharedModule, CommonModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AccessTokenInterceptor,
      multi: true
    },
    AuthenticationService,
    SecurityConfigService,
    CryptoService
  ],
  declarations: [LoginComponent],
  exports: [LoginComponent]
})
export class SecurityModule {}
