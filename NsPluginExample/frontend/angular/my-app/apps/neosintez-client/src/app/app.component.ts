import { AuthenticationService } from './../../../../libs/Security/services/authentication.service';
import { AppEnvironmentService } from './services/app-environment.service';
import { Component, OnInit, OnDestroy, Inject } from '@angular/core';

/**Главнй компонент приложения */
@Component({
  selector: 'my-app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'neosyntez client';
  executeIntoFrame = this.environmentService.inIFRAME;
  get isAuthenticated() {
    return this.authService.isAuthenticated;
  }

  constructor(
    private readonly environmentService: AppEnvironmentService,
    private readonly authService: AuthenticationService
  ) {}

  ngOnInit(): void {}

  ngOnDestroy() {}
}
