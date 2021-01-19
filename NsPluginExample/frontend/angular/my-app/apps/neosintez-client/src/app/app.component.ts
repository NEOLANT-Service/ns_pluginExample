import { NeosyntezContextService } from '../../../../libs/Shared/services/neosyntez-context.service';
import {
  IAppConfig,
  AppAuthType
} from './../../../../libs/Shared/services/backend/config.service';
import { takeUntil } from 'rxjs/operators';
import { AuthenticationService } from '../../../../libs/Security/services/authentication.service';
import { AppEnvironmentService } from './services/app-environment.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ConfigService } from 'libs/Shared/services/backend/config.service';
import { Subject } from 'rxjs';

/**Главнй компонент приложения */
@Component({
  selector: 'my-app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'neosyntez client';
  executeIntoFrame = this.environmentService.inIFRAME;
  config: IAppConfig;

  readonly AuthType = AppAuthType;

  get isAuthenticated() {
    if (this._isReady) {
      switch (this.config.neosyntezClient.authType) {
        case this.AuthType.ImplicitFlow:
        case this.AuthType.AccessToken:
          return this.authService.isAuthenticated;
        default:
          return true;
      }
    }
    return false;
  }

  private _isReady: boolean = false;
  get isReady(): boolean {
    return this._isReady;
  }

  private _ngUnsubscribe: Subject<void> = new Subject();

  constructor(
    private readonly environmentService: AppEnvironmentService,
    private readonly authService: AuthenticationService,
    private readonly configService: ConfigService,
    readonly neosintezContext: NeosyntezContextService
  ) {}

  ngOnInit(): void {
    this._fetchConfig();
  }

  ngOnDestroy() {
    this._ngUnsubscribe.next();
    this._ngUnsubscribe.complete();
  }

  private _fetchConfig() {
    this.configService
      .fetch()
      .pipe(takeUntil(this._ngUnsubscribe))
      .subscribe({
        next: x => {
          this._isReady = true;
          this.config = x;
          this.neosintezContext.init();
        },
        error: ex => {
          this._isReady = false;
        }
      });
  }
}
