export interface IP3DBPluginInstanceCacheService {
    /**Вернет, существует ли в кеше именнованный экземпляр плагина*/
    isExists(name: string | Element): boolean;

    /**Вернет экземплря плагина из кеша
     * @param name имя экземпляра плагина
     */
    get(name: string): Element | undefined;

    /**Сохранит экземпляр плагина в кеше
     * @param name имя экземпляра плагина
     */
    set(plugin: Element): void;

    /**Производит очистку кеша */
    clear(): void;

    /** Уничтожение кеша*/
    destruct(): void;
}

