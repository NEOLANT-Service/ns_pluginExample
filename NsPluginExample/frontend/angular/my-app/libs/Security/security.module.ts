import { SharedModule } from './../Shared/shared.module';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationService } from './services/authentication.service';
import { AccessTokenInterceptor } from './services/access-token.interceptor';

@NgModule({
  imports: [SharedModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AccessTokenInterceptor,
      multi: true
    },
    AuthenticationService
  ]
})
export class SecurityModule {}
