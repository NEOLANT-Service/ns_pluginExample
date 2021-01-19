import { IP3DBPluginInstanceCacheService } from './p3db-instance-cache';

/**Эмуляция кеша */
export class P3DBPluginInstanceNoneCache
    implements IP3DBPluginInstanceCacheService {
    constructor() {}
    isExists(name: string | Element): boolean { return false; }
    get(name: string): Element | undefined { return undefined; }
    set(plugin: Element): void { }
    clear(): void { }
    destruct(): void { }
}

