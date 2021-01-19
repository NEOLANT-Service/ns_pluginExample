import { ViewOptionsType } from "./../p3dbplugin.type";
import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";

export class P3DBPluginWrapperCamera {
    constructor(private readonly wrapper: IP3DBPluginWrapper) {}

    /**Параллельный перенос камеры в направлении выделенных элементов*/
    centerOnSelected(): void {
        this.wrapper.plugin.CenterViewOnSelected();
    }

    get state(): ICameraState {
        const str = this.wrapper.plugin.CameraState;
        return this.wrapper.fromJSON<ICameraState>(str)!;
    }

    set state(value: ICameraState) {
        const str = this.wrapper.toJSON(value);
        this.wrapper.plugin.CameraState = str;
    }
}

export interface ICameraState {
    Camera: {
        A: number;
        Distance: number;
        Latitude: number;
        Longitude: number;
        X: number;
        Y: number;
        Z: number;
    };
}
