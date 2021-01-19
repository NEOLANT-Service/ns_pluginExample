import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";

export class P3DBPluginWrapperLog {
    private static _logs: Record<string, {
        date: Date,
        message: string,
        error: boolean
    }[] | undefined>;

    private _isDebugModeOn: boolean | undefined;

    constructor(private readonly wrapper: IP3DBPluginWrapper) {
        if (!P3DBPluginWrapperLog._logs) P3DBPluginWrapperLog._logs = {};
    }

    info(message: string) {
        if (message) {
            if (this.isDebugModeOn) {
                this.wrapper.plugin.SendToLog(message, false);
                this._addLog(message, false);
            }
        }
    }

    error(message: string) {
        if (this.isDebugModeOn) {
            this.wrapper.plugin.SendToLog(message, true);
            this._addLog(message, true);
        }
    }

    getLogs() {
        return P3DBPluginWrapperLog._logs[this.wrapper.instanceName] || [];
    }

    destruct() {
        delete P3DBPluginWrapperLog._logs[this.wrapper.instanceName];
        P3DBPluginWrapperLog._logs[this.wrapper.instanceName] = undefined;
    }

    /**Признак включенного режима отладки 
     * Experimental
    */
    get isDebugModeOn(): boolean {
        if (this._isDebugModeOn === undefined)
            this._isDebugModeOn = this.wrapper.plugin.IsDebugMode;
        return this.wrapper.plugin.IsDebugMode;
    }

    private _addLog(message: string, error: boolean) {
        if (P3DBPluginWrapperLog._logs[this.wrapper.instanceName] === undefined) {
            P3DBPluginWrapperLog._logs[this.wrapper.instanceName] = [];
        }
        P3DBPluginWrapperLog._logs[this.wrapper.instanceName]!.push({ date: new Date(), message, error })
    }
}