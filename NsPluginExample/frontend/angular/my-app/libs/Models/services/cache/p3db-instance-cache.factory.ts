import { InjectionToken } from '@angular/core';
import { IP3DBPluginInstanceCacheService } from './p3db-instance-cache';
import { P3DBPluginInstanceLimboCache } from './p3db-instance-limbo-cache';
import { P3DBPluginInstanceMemoryCache } from './p3db-instance-memory-cache';
import { P3DBPluginInstanceMemorySingletonCache } from './p3db-instance-memory-singleton';
import { P3DBPluginInstanceNoneCache } from './p3db-instance-none-cache';

export const P3DBPluginInstanceCacheService = new InjectionToken('P3DBPluginInstanceCacheService');

/**Фабрика  кеша экземпляров плагина*/
export function p3dbInstanceCacheFactory(type: P3DBInstanceCacheType) {
    return ($window: Window): IP3DBPluginInstanceCacheService => {
        switch (type) {
            case P3DBInstanceCacheType.Limbo:
                return new P3DBPluginInstanceLimboCache($window);
            case P3DBInstanceCacheType.Memory:
                return new P3DBPluginInstanceMemoryCache();
            case P3DBInstanceCacheType.MemorySingleton:
                return new P3DBPluginInstanceMemorySingletonCache();
            default:
                return new P3DBPluginInstanceNoneCache();
        }
    }
}

/**Тип кеша экземпляра плагина*/
export enum P3DBInstanceCacheType {
    /**Заглушка (не используется)*/
    None = 0,
    /**В качетстве хранилища используется разметка */
    Limbo,
    /**Память */
    Memory,
    /**Синглтон */
    MemorySingleton
}