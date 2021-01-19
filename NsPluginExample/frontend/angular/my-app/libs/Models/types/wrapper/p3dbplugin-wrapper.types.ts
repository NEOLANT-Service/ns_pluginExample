import {
  P3dbPlugin,
  Plugin3DEvent,
  IPluginInformation
} from '../p3dbplugin.type';
import { P3DBPluginWrapperCache } from './p3dbplugin-wrapper-cache';
import { P3DBPluginWrapperScene } from './p3dbplugin-wrapper-scene';
import { P3DBPluginWrapperSelection } from './p3dbplugin-wrapper-selection';
import { P3DBPluginWrapperClipping } from './p3dbplugin-wrapper-clip';
import { P3DBPluginWrapperUI } from './p3dbplugin-wrapper-ui';
import { P3DBPluginWrapperCamera } from './p3dbplugin-wrapper-camera';
import { P3DBPluginWrapperFly } from './p3dbplugin-wrapper.fly';
import { P3DBPluginWrapperLog } from './p3dbplugin-wrapper-log';
import { P3DBPluginWrapperSearch } from './p3dbplugin-wrapper-search';
import { P3DBPluginWrapperEvents } from './p3dbplugin-wrapper-events';
import { IP3DBPluginException } from '../p3dbplugin-exceptions.type';
import { P3DBPluginWrapperState } from './p3dbplugin-wrapper-state';

export interface IP3DBPluginWrapper {
  readonly pluginElement: HTMLObjectElement;
  readonly instanceName: string;
  readonly plugin: P3dbPlugin;
  readonly cache: P3DBPluginWrapperCache;
  readonly scene: P3DBPluginWrapperScene;
  readonly selection: P3DBPluginWrapperSelection;
  readonly clipping: P3DBPluginWrapperClipping;
  readonly ui: P3DBPluginWrapperUI;
  readonly camera: P3DBPluginWrapperCamera;
  readonly fly: P3DBPluginWrapperFly;
  readonly log: P3DBPluginWrapperLog;
  readonly search: P3DBPluginWrapperSearch;
  readonly events: P3DBPluginWrapperEvents;

  isInterrupting: boolean;
  isDebugMode: boolean;
  information: IPluginInformation;
  state: P3DBPluginWrapperState;

  abort: () => void;
  abortAsync: () => void;
  addEvent: (
    event: Plugin3DEvent,
    listner: (_: any, ...args: any[]) => void
  ) => void;
  removeEvent: (
    event: Plugin3DEvent,
    listner: (_: any, ...args: any[]) => void
  ) => void;
  fromJSON: <T>(json: string) => T;
  toJSON: (obj: any) => string;
  ASSERT: (
    state: IPluginEventArgs<any>,
    resolved?: string,
    error?: string
  ) => boolean;
}

export interface IP3DBPluginAuthorizationOptions {
  /**Схема авторизации: например Bearer */
  scheme: string;
  /**Токен безопасности */
  token: string;
}

/**Общая модель для асинхронных операций */
export interface IPluginEventArgs<T> {
  result?: T;
  exception: IP3DBPluginException;
}
