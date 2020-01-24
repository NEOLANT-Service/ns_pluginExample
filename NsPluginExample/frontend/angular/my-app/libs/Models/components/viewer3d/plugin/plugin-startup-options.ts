/** Настройки, необходимые для инициализации плагина */
export class P3dbPluginOptions implements IP3dbPluginOptions {
  private _cullingTreshold: number;
  private _debug: boolean;
  private _version: string;
  private _licenceUrl: string;

  get ContributionCullingThreshold(): number | undefined {
    return this._cullingTreshold;
  }
  get Debug(): boolean | undefined {
    return this._debug;
  }
  get Version(): string {
    return this._version;
  }
  get LicenceUrl(): string {
    return this._licenceUrl;
  }

  /**Конструктор */
  constructor(cullingTreshold: number, debug: boolean, version: string, licenceUrl: string) {
    this._cullingTreshold = cullingTreshold;
    this._debug = debug;
    this._version = version;
    this._licenceUrl = licenceUrl;
  }
}


/**Опции плагина, необходимые для его инициализации */
export interface IP3dbPluginOptions {
  ContributionCullingThreshold: number;
  Debug: boolean;
  Version: string;
  LicenceUrl: string;
}
