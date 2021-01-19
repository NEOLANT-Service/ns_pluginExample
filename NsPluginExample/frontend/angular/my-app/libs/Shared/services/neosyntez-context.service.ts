import { Injectable } from '@angular/core';
import { guid } from '../../../apps/neosintez-client/src/app/shared/types';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/internal/operators/map';

let _context: INeosyntezContext;

@Injectable()
export class NeosyntezContextService {
  constructor(private readonly activatedRoute: ActivatedRoute) {}

  init() {
    this._getLocationParamas();
  }

  get(): INeosyntezContext {
    return _context;
  }

  private _set(context: INeosyntezContext) {
    if (!_context) _context = context;
  }

  private _getLocationParamas() {
    const subscribe = this.activatedRoute.queryParams
      .pipe(
        map(x => {
          const context = {
            access_token: <string>x['token'],
            objectId: x['objectId'],
            url: x['url'] || this._getURL()
          };
          return context;
        })
      )
      .subscribe(x => {
        this._set(x);
        subscribe && subscribe.unsubscribe();
      });
  }

  private _getURL() {
    return window.location !== window.parent.location
      ? document.referrer
      : document.location.href;
  }
}

export interface INeosyntezContext {
  /**Идентификатор объекта */
  objectId: guid;
  /**Токен безопасности */
  access_token: string;
  /**Адрес инстанса, вызывающего сервис */
  url: string;
}
