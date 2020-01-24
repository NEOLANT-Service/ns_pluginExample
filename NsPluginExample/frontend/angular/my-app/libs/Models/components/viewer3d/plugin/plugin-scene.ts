import { IP3dbPlugin, ILoadModelInfo } from './plugin-intsance';
export class P3DBPluginScene {
  constructor(private plugin: IP3dbPlugin) { }

  /**Загрузит сцену */
  loadScene(files: any = {}) {
    this.plugin.LoadModel(JSON.stringify({ Content: files }));
  }

  /**Добавит файлы в сцену */
  addFiles(files: any[]) {
    this.plugin.Scene_AddFiles(JSON.stringify({ Content: files }));
  }

  /**Удалит файлы из сцены */
  removeFiles(files: any) {
    this.plugin.Scene_RemoveFiles(JSON.stringify({ Content: files }));
  }

  /**Очистит сцену */
  clear() {
    this.plugin.Scene_Clear();
  }

  /**Вернет список файлов сцены */
  fetchFiles(): ILoadModelInfo[] {
    const s = this.plugin.Scene_GetFiles();
    console.log(s);
    if (s) {
      try {
        const obj = JSON.parse(s) as IPluginFiles;
        return obj.Content;
      } catch (ex) {
        console.error(ex);
      }
    }
    return [];
  }
}

interface IPluginFiles {
  Content: ILoadModelInfo[]
}
