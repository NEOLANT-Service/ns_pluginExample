import { AppEnvironmentService } from './app-environment.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AvailableGuard implements CanActivate {
  constructor(
    private environmentService: AppEnvironmentService,
    private router: Router
  ) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (this.environmentService.inIFRAME) {
      this.router.navigate(['/notfound']);
      return false;
    }
    return true;
  }

}
