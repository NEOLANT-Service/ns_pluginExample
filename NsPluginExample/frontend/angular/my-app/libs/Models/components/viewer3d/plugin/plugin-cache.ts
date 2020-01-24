import { IP3dbPlugin } from './plugin-intsance';
export class P3DBPluginCache {
  constructor(private plugin: IP3dbPlugin) {

  }

  /**Удалит все файлы в кеше */
  clear() {
    this.plugin.Cache_Clear();
  }

  /**Верент список файлов, находящихся в кеше */
  fetchFiles() {
    this.plugin.Cache_GetFiles();
  }

  /**Удалит из кеша файлы*/
  remove(files: any[]) {
    this.plugin.Cache_RemoveFiles(JSON.stringify(files));
  }
}
