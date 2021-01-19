import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";

export class P3DBPluginWrapperSearch {
    constructor(private readonly wrapper: IP3DBPluginWrapper) {

    }

    getAncestors(uid: number): number[] {
        const str = this.wrapper.plugin.GetAncestors(uid);
        return this.wrapper.fromJSON<number[]>(str)!;
    }
}