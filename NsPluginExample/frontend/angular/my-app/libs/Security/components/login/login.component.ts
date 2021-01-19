import { AppAuthType } from 'libs/Shared/services/backend/config.service';
import { ConfigSnapshotService } from 'libs/Shared/services/config-snapshot.service';
import { Component, OnInit } from '@angular/core';
import { LoggerService } from 'libs/Shared/services/logger.service';
import { WindowService } from 'libs/Shared/services/window.service';
import { authenticationServiceProvider } from 'libs/Security/services/authentication.factory';
import { AuthenticationService } from 'libs/Security/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less'],
  providers: [authenticationServiceProvider]
})
export class LoginComponent implements OnInit {
  private url: string;
  private win?: Window;
  error?: string;

  constructor(
    private readonly windowService: WindowService,
    private readonly authService: AuthenticationService,
    private readonly configService: ConfigSnapshotService,
    private readonly logger: LoggerService
  ) {}

  ngOnInit(): void {
    switch (this.configService.authType) {
      case AppAuthType.ImplicitFlow:
        this._implisitFlowInit();
        break;
      case AppAuthType.AccessToken:
        this._accessTokenInit();
        break;
    }
  }

  logInHandler() {
    this.win = this.windowService.nativeWindow.window.open(this.url, undefined);
    if (!this.win) this.error = 'Не удалось открыть форму логина';
  }

  private _implisitFlowInit() {
    const [url, promise] = this.authService.connect();
    this.url = url;

    promise
      .then(() => {
        this.windowService.nativeWindow.window.location.reload();
        this.win && this.win.close();
      })
      .catch(e => {
        this.logger.error(
          this.authService.isOAuthError(e)
            ? `${e.error}: ${e.error_description}`
            : e.message || e,
          e
        );
        this.error = this.authService.isOAuthError(e)
          ? `Обратитесь к администратору (${e.error_description})`
          : 'Попробуйте зайти позднее или обратитесь к администратору';
        this.win && this.win.close();
      });
  }

  private _accessTokenInit() {
    this.authService.connect();
    this.windowService.nativeWindow.window.location.reload();
  }
}
