import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";

/**Враппер сечений плагина P3DB */
export class P3DBPluginWrapperClipping {
    constructor(private readonly wrapper: IP3DBPluginWrapper) {

    }

    clip(uids: number[]) {
        const str = this.wrapper.toJSON(uids);
        this.wrapper.plugin.Clip(str);
    }

    reset() {
        this.wrapper.plugin.ResetClip();
    }

    createBoxByFindList(): number {
        return this.wrapper.plugin.ClipCreateBoxByFindList();
    }

    setActivePlane(planIndex: number, active: boolean) {
        this.wrapper.plugin.ClipSetActive(planIndex, active);
    }

    get clipState(): IClipPlan[] {
        const str = this.wrapper.plugin.ClipState;
        const obj = this.wrapper.fromJSON<{ ClipList: IClipPlan[] }>(str);
        return obj!.ClipList;
    }

    set clipState(clipPlans: IClipPlan[]) {
        const str = this.wrapper.toJSON({ ClipList: clipPlans });
        this.wrapper.plugin.ClipState = str;
    }

    get distanceShift(): number {
        return this.wrapper.plugin.ClipDistanceShift;
    }

    set distanceShift(shift: number) {
        this.wrapper.plugin.ClipDistanceShift = shift;
    }
}

/**Поверхность сечения */
export interface IClipPlan {
    /**Признак активности */
    Active: number;

    /**Дистанция до начала координат */
    Distance: number;

    /**Плоскость */
    Plane: { X: number, Y: number, Z: number }
}