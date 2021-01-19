import { Deferred } from 'libs/Shared/types/deferred';


/**Класс, отвечающий за  обработку двойного щелчка мыши, для исключения ложного срабатывания события клика*/
export class P3DBPluginDblClickManager {
    private _timer: number | undefined;
    private _isDblClick: boolean;
    private _def: Deferred<void> | undefined;

    begin(debounce: number = 250): Promise<void> {
        if (this._def)
            return this._def.promise;
        this._def = new Deferred();
        if (!this.inWaitMode) {
            this._timer = window.setTimeout(() => {
                if (!this._isDblClick) {
                    this._def!.resolve();
                }
                this.complete();
            }, debounce)
        } else {
            this._def.reject();
        }
        return this._def.promise;
    }

    check() {
        this._isDblClick = true;
    }

    complete() {
        clearTimeout(this._timer);
        this._timer = undefined;
        this._isDblClick = false;
        this._def = undefined;
    }

    get inWaitMode() { return !!this._timer }
}
