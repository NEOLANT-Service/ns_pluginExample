import { AppEnvironmentService } from './services/app-environment.service';
import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { Subscription } from 'rxjs';

/**Главнй компонент приложения */
@Component({
  selector: 'my-app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'neosyntez client';

  executeIntoFrame = this.environmentService.inIFRAME;

  private routerSubscription: Subscription;

  constructor(
    private router: Router,
    private environmentService: AppEnvironmentService) {
  }

  ngOnInit(): void {
    this.routerSubscription = this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        console.log('Navigation End %o', event.url);
      }
    })
  }

  ngOnDestroy() {
    this.routerSubscription && this.routerSubscription.unsubscribe();
  }
}
