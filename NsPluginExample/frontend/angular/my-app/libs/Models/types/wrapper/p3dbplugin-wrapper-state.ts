import { Deferred } from 'libs/Shared/types/deferred';
import { P3dbLoadingState } from "../p3dbplugin.type";

/**Описание состояния плагина */
export class P3DBPluginWrapperState {
    get loadingState(): P3dbLoadingState | null { return this._loadingState; }
    get loading(): Deferred<void> | null { return this._loading; }
    get aborting(): Deferred<void> | null { return this._aborting; }
    get conveyorCondition(): PluginWrapperConveyorCondition { return this._conveyorCondition; }

    private _loadingState: P3dbLoadingState | null = null;
    private _loading: Deferred<void> | null = null;
    private _aborting: Deferred<void> | null = null;
    private _conveyorCondition: PluginWrapperConveyorCondition = PluginWrapperConveyorCondition.None;

    /** Выставляет состояние в прерываение любых операций конвеера.
     * Если такая операция уже выполняется, то дожидается ее окончания чтобы выполнить новую
    */
    async beginAborting() {
        if (this._aborting) await this._aborting;
        this._aborting = new Deferred<void>()
        this._aborting.promise.finally(() => {
            this.setConveyourCondtition(PluginWrapperConveyorCondition.None);
            this._aborting = null;
        })
        return this._aborting;
    }

    /**Меняет состояние на начало загрузки */
    beginLoading() {
        this.startConveyor();
        this._loading = new Deferred<void>();
        return this._loading;
    }

    /**Установить состояние конвеера */
    setConveyourCondtition(condition: PluginWrapperConveyorCondition) {
        this._conveyorCondition = condition;
    }

    /**Перезапускает конвеер */
    startConveyor() {
        this._aborting = null;
        this.setConveyourCondtition(PluginWrapperConveyorCondition.None);
        this._loadingState = null;
    }
}

export enum PluginWrapperConveyorCondition {
    /**Конвеер загрузки закончил работу или не начинал */
    None = 0,
    /**Подготовка сцены (удаление/очистка) */
    PrepareScene = 1,
    /**Загрузка в кеш */
    LoadToCache = 2,
    /**Загрузка на сцену*/
    LoadToScene = 3,
}
