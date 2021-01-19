import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";

export class P3DBPluginWrapperSelection {

    constructor(private readonly wrapper: IP3DBPluginWrapper) {

    }

    /**Возвращает массив UID выделенных элементов */
    getSelectedUIDs(): number[] {
        const str = this.wrapper.plugin.GetSelectedUIDs();
        const obj = this.wrapper.fromJSON<{ array: number[] }>(str);
        return obj ? obj.array : [];
    }

    /**Сброс выделения */
    resetSelection() {
        this.wrapper.plugin.ResetSelection();
    }

    /**Выделить элементы*/
    selectElementGroups(groups: SelectionGroup[], mode: SelectionMode) {
        this.wrapper.plugin.SelectElementGroups(this.wrapper.toJSON({ g: groups }), mode);
    }
}

export interface SelectionGroup {
    Ids?: number[];
    All?: boolean;

    Color?: string;
    Select?: boolean;
    Fit?: boolean;
}

export enum SelectionMode {
    All = 0,
    Only = 1,
    // Except = 2 - not implemented
}