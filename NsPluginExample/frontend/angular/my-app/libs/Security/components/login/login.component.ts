import { Component, OnInit } from '@angular/core';
import {
  AuthenticationService,
  isOAuthError
} from 'libs/Security/services/authentication.service';
import { LoggerService } from 'libs/Shared/services/logger.service';
import { WindowService } from 'libs/Shared/services/window.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  private url: string;
  private win?: Window;
  error?: string;

  constructor(
    private readonly windowService: WindowService,
    private authService: AuthenticationService,
    private logger: LoggerService
  ) {}

  ngOnInit(): void {
    const [url, promise] = this.authService.connect();
    this.url = url;

    promise
      .then(() => {
        this.windowService.nativeWindow.window.location.reload();
        this.win && this.win.close();
      })
      .catch(e => {
        this.logger.error(
          isOAuthError(e)
            ? `${e.error}: ${e.error_description}`
            : e.message || e,
          e
        );
        this.error = isOAuthError(e)
          ? `Обратитесь к администратору (${e.error_description})`
          : 'Попробуйте зайти позднее или обратитесь к администратору';
        this.win && this.win.close();
      });
  }

  logIn() {
    this.win = this.windowService.nativeWindow.window.open(this.url, undefined);
    if (!this.win) this.error = 'Не удалось открыть форму логина';
  }
}
