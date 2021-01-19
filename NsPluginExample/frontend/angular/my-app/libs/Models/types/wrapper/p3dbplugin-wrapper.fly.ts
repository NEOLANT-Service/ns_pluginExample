import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";

export class P3DBPluginWrapperFly {
    constructor(private readonly wrapper: IP3DBPluginWrapper) {

    }

    /**Вернет наименование точек облета */
    getFlyPoints(): string[] {
        return this.wrapper.fromJSON<string[]>(this.wrapper.plugin.GetFlybys())!;
    }

    /**Задает точку обзора в качестве текущей по ее имени*/
    setCurrentFlyPoint(name: string) {
        this.wrapper.plugin.SetFlyby(name);
    }

    /**Начать облет по точкам обзора */
    start() {
        this.wrapper.plugin.StartFlyBy();
    }

    pause() {
        this.wrapper.plugin.PauseFlyBy();
    }

    setPosition(percent: number) {
        this.wrapper.plugin.SetFlyByPositon(percent);
    }
}