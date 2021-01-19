import {
  IP3DBPluginAuthorizationOptions,
  IP3DBPluginWrapper
} from './p3dbplugin-wrapper.types';
import { ISceneLoad } from './p3dbplugin-wrapper-scene';
import { P3DBSceneLoadMode } from '../p3dbplugin.type';
import { PluginWrapperConveyorCondition } from './p3dbplugin-wrapper-state';

/**Менеджер загрузки сцены */
export class P3DBPlugin_LoadManager {
  constructor(private readonly wrapper: IP3DBPluginWrapper) {}

  /**Загружает сцену
   * @param items описание сцены
   * @param authorization информация о токене безопасности
   */
  async loadAsync(
    items: ISceneLoad[],
    authorization?: IP3DBPluginAuthorizationOptions
  ) {
    const commands = this._buildCommands(this._geUniqueItems(items));
    try {
      this.wrapper.scene.beginUpdate();
      await this._load(commands, authorization);
    } catch (ex) {
      throw ex;
    } finally {
      this.wrapper.scene.endUpdate();
    }
  }

  /**Прерывание загрузки сцены */
  abort() {
    this.wrapper.cache.abort();
    this.wrapper.scene.abort();
  }

  /**Формирование команд*/
  private _buildCommands(newModels: ISceneLoad[]) {
    const sceneModels = this.wrapper.scene.getModels();
    let commands: IManagerCommand[] = [];

    commands.push(
      ...sceneModels.map(x => {
        let inNewModels = newModels.some(z => this._comparator(z, x));
        let action: ManagerActionType = ManagerActionType.DeleteFromScene;
        if (inNewModels || x.path === 'noname.p3db') {
          action = ManagerActionType.None;
        }
        return this._getCommand(x, action);
      })
    );
    let findDuplicates = (arr: any[]) =>
      arr.filter((item: any, index: number) => arr.indexOf(item) != index);
    if (findDuplicates(commands.map(x => x.payload.path)).length > 0) {
    }
    newModels = newModels.filter(x => {
      return !sceneModels.some(z => this._comparator(x, z));
    });
    //Создаем команды для моделей, которые необходимо загрузить в сцену
    commands.push(
      ...newModels
        .filter(x => sceneModels.some(z => !this._comparator(z, x)))
        .map(x => this._getCommand(x, ManagerActionType.LoadFromStore))
    );
    return commands;
  }

  private async _load(
    commands: IManagerCommand[],
    authorization: IP3DBPluginAuthorizationOptions
  ) {
    const cacheModels = this.wrapper.cache.getModels();
    const leaving = commands.filter(x => x.action === ManagerActionType.None);
    const deleting = commands
      .filter(x => x.action === ManagerActionType.DeleteFromScene)
      .reverse();
    const fromStore = commands.filter(
      x =>
        x.action === ManagerActionType.LoadFromStore &&
        !cacheModels.find(z => this._comparator(z, x.payload))
    );
    const fromCache = commands.filter(
      x => x.action === ManagerActionType.LoadFromStore
    );

    const loading = await this.wrapper.state.beginLoading();
    this.wrapper.state.setConveyourCondtition(
      PluginWrapperConveyorCondition.PrepareScene
    );
    await this._deleteFromScene(deleting);
    if (this.wrapper.isInterrupting) {
      throw '';
    }
    this.wrapper.state.setConveyourCondtition(
      PluginWrapperConveyorCondition.LoadToCache
    );
    await this._loadFromStore(fromStore, authorization);
    if (this.wrapper.isInterrupting) {
      throw '';
    }
    this.wrapper.state.setConveyourCondtition(
      PluginWrapperConveyorCondition.LoadToScene
    );
    await this._loadFromCache(fromCache);
    if (this.wrapper.isInterrupting) {
      throw '';
    }
    this.wrapper.cache.manager.updateIndexes(leaving.map(x => x.payload.path));
    if (this.wrapper.isInterrupting) {
      throw '';
    }
    await this.wrapper.cache.manager.normalizeAsync(
      fromCache.map(x => x.payload.path)
    );
    this.wrapper.state.setConveyourCondtition(
      PluginWrapperConveyorCondition.None
    );
    await loading.resolve();
  }

  private async _deleteFromScene(commands: IManagerCommand[]) {
    for (let i = 0; i <= commands.length - 1; i++) {
      await this.wrapper.scene.unloadModel(commands[i].payload.path);
      if (this.wrapper.isInterrupting) return;
    }
  }

  private async _loadFromStore(
    commands: IManagerCommand[],
    authoriztion?: IP3DBPluginAuthorizationOptions
  ) {
    if (commands && commands.length > 0) {
      return this.wrapper.cache.loadFromUriAsync(
        commands.map(x => {
          return {
            path: x.payload.path,
            size: x.payload.size,
            name: x.payload.name
          };
        }),
        authoriztion
      );
    }
  }

  private async _loadFromCache(commands: IManagerCommand[]) {
    let mode: P3DBSceneLoadMode = P3DBSceneLoadMode.Npl_File_AsRef;
    for (let i = 0; i <= commands.length - 1; i++) {
      await this.wrapper.scene.loadFromCacheAsync(
        commands[i].payload.path,
        mode
      );
      if (this.wrapper.isInterrupting) return;
    }
  }

  private _comparator<T1 extends { path: string }, T2 extends { path: string }>(
    a: T1,
    b: T2
  ) {
    return a.path.toLowerCase() === b.path.toLowerCase();
  }

  /**Формирует команду */
  private _getCommand<T extends { path: string; size: number; name: string }>(
    a: T,
    actionType: ManagerActionType
  ): IManagerCommand {
    return {
      action: actionType,
      payload: {
        path: a.path,
        size: a.size,
        name: a.name
      }
    };
  }

  private _geUniqueItems(items: ISceneLoad[]) {
    let unique: Record<string, number> = {};
    let distinct: ISceneLoad[] = [];
    for (let i = 0; i < items.length; i++) {
      if (!unique[items[i].path]) {
        distinct.push(items[i]);
        unique[items[i].path] = 1;
      }
    }
    return distinct;
  }
}

interface IManagerCommand {
  action: ManagerActionType;
  payload: IManagerPayload;
}

interface IManagerPayload {
  path: string;
  size: number;
  name: string;
}

enum ManagerActionType {
  None = 0,
  LoadFromStore = 1,
  DeleteFromScene = 2
}

export interface ILoadManagerProviders {
  /**Компаратор наименований моделей */
  modelNameComparator: <T1 extends { URL: string }, T2 extends { URL: string }>(
    a: T1,
    b: T2
  ) => boolean;
  modelHashGenerator: <T extends { URL: string; Hash: string }>(
    model: T
  ) => string | undefined;
}
