import { Injectable } from '@angular/core';
import { guid } from '../shared/types';
import { ActivatedRoute } from '@angular/router';

let _context: INeosintezContext;

@Injectable()
export class NeosintezContextService {
  constructor(private readonly activatedRoute: ActivatedRoute) {}

  init() {
    this._getLocationParamas();
  }

  get(): INeosintezContext {
    return _context;
  }

  private _set(context: INeosintezContext) {
    if (!_context) _context = context;
  }

  private _getLocationParamas() {
    const subscribe = this.activatedRoute.queryParams.subscribe(x => {
      const context = {
        access_token: <string>x['access_token'],
        objectId: x['objectId']
      };

      this._set(context);
      subscribe && subscribe.unsubscribe();
    });
  }
}

export interface INeosintezContext {
  objectId: guid;
  access_token: string;
}
