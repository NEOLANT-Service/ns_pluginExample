export class Deferred<T>
{
    readonly promise: Promise<T>;

    private _resolve: (value?: T | PromiseLike<T>) => void;
    get resolve() { return this._resolve; }

    private _reject: (reason?: any) => void;
    get reject() { return this._reject; }

    constructor()
    {
        this.promise = new Promise<T>((r, rj) =>
        {
            this._resolve = r;
            this._reject = rj;
        });
    }
}
