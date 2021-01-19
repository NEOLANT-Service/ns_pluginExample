import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpInterceptor,
  HttpHandler,
  HttpErrorResponse
} from '@angular/common/http';
import { from } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class AccessTokenInterceptor implements HttpInterceptor {
  constructor(public auth: AuthenticationService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    return from(this.interceptAsync(request, next));
  }

  private async interceptAsync(request: HttpRequest<any>, next: HttpHandler) {
    if (this.auth.isAuthenticated) {
      request = request.clone({ setHeaders: await this.auth.getAuthHeader() });
    }

    try {
      return await next.handle(request).toPromise();
    } catch (e) {
      if (
        e instanceof HttpErrorResponse &&
        e.status === 401 &&
        this.auth.isAuthenticated
      )
        this.auth.disconnect();
      throw e;
    }
  }
}
