import { Inject, Injectable } from '@angular/core';
import { WINDOW } from '../../../Shared/tokens/shareds.token';

@Injectable({
    providedIn: "root"
})
export class P3DBPluginAvailableService {
    constructor(
        @Inject(WINDOW) private _window: any
    ) {

    }

    async isAvailableAsync() {
        return Promise.resolve(this.isAvailable());
    }

    isAvailable(): boolean {
        if (IS_AVAILABLE === undefined) {
            const isIEOrEdge = /msie\s|trident\//i.test(this._window.navigator.userAgent);
            if (isIEOrEdge) {
                IS_AVAILABLE = true;

            } else {
                IS_AVAILABLE = false;
            }
        }
        return IS_AVAILABLE;
    }
}

let IS_AVAILABLE: boolean | undefined;
