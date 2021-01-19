import { SelectionGroup, SelectionMode } from './wrapper/p3dbplugin-wrapper-selection';

export interface P3dbPlugin
    extends IP3DBPlugin_Scene,
        IP3DBPlugin_Cache,
        IP3DBPlugin_UI,
        IP3DBPlugin_Utils,
        IP3DBPlugin_Camera,
        IP3DBPlugin_Elements,
        IP3DBPlugin_Clip,
        IP3DBPlugin_Fly {
    BeginDeInitialization(): void;
    PluginInitialize(debug: boolean): void;

    GetInformation(): string;

    OpenFileDialogShow(options: string): string;

    licenceurl: string;
    license: string;

    /**Версия плагагина */
    Version: string;

    /**Параметр отвечает за ограничение отображения мелких элементов для настройки производительности */
    contributionCullingThreshold: string;

    /**Признак включенной отладки*/
    IsDebugMode: boolean;
}

/**Методы для работы с сечениями */
interface IP3DBPlugin_Clip {
    /**Создает плоскости сечения по области которую занимают элементы с конкретными UID.
     * @param uids - идентификаторы элементов
     * @example
     * Plugin.Clip('711501,711502,711453');
     */
    Clip(uids: string): void;
    ResetClip(): void;
    ClipDeleteAll(): void;

    /**Позволяет задать или получить состояние 6 основных секущих плоскостей в виде строки содержащей структуру формата JSON*/
    ClipState: string;

    /**Создает сечения по координатам в которых находятся элементы помещенные в итератор поиска*/
    ClipCreateBoxByFindList(): number;

    /**Устанавливает отклонение поверхности плоскости сечения от элементов, что бы компенсировать возможное параллельное пересечение с плоскостями */
    ClipDistanceShift: number;

    ClipSetActive(index: number, active: boolean): void;
}

/**Методы для работы со сценой плагина */
interface IP3DBPlugin_Scene {
    /**Очищает сцену*/
    SceneClear(): void;
    SceneLoadFromCacheAsync(path: string, mode: P3DBSceneLoadMode): void;
    SceneLoadFromFileAsync(path: string, mode: P3DBSceneLoadMode): void;
    SceneGetFiles(): string;
    SceneUnload(path: string): void;

    /**Настройки сцены ISceneSettings*/
    SceneSettings: string;

    /**Скрыть 3D сцену с заливкой заданого цвета */
    SceneCloak(hide: boolean, color?: string): void;

    /**Прерывание операций плагина */
    Interrupt(): void;

    /**Скрывает или показывает сцену */
    SceneVisible(value: boolean): void;

    /**Прерывает загрузку в сцену*/
    SceneAbortLoading(): void;

    /**Получение режима отображения*/
    ViewGetMode(mode: ViewOptionsType): number;

    /**Установка режима отображения */
    ViewSetMode(mode: keyof ViewOptionsType | number, value: number): void;
}

/**Методы для работы с кешем плагина */
interface IP3DBPlugin_Cache {
    CacheLoadFromUriAsync(payload: string, authorization?: string): void;
    CacheClear(): void;
    CacheGetFiles(): string;

    /**Выгружает из кеша файл
     * @param keyPath URI по котрому был загружен файл
     */
    CacheUnload(keyPath: string): void;

    /**Прерывает загрузку в кеш*/
    CacheAbortLoading(): void;
}

/**Методы для работы с интрефейсом плагина */
interface IP3DBPlugin_UI {
    /**Видимость элементов управления p3d. Параметры принимают 1 или 0.
     * @param menu - видимость меню
     * @param toolbar - видимость элементов toolbar
     * @param statusbar - видимость statusbar (нижняя панель)
     * @param toolpad видимость toolpad
     */
    ApiControlsVisible(
        menu: number,
        toolbar: number,
        statusbar: number,
        toolpad: number
    ): void;

    AddContextMenuCommands(commands: string): void;

    ViewSetColor(
        type: ViewColorType,
        red: number,
        green: number,
        blue: number,
        alpha: number
    ): void;

    /** */
    CMenuCmdGroup(name: string): void;

    CMenuCmdReg(index: number, name: string): void;
}

/**Методы для работы с камерой сцены */
interface IP3DBPlugin_Camera {
    CameraState: string;

    /**Параллельный перенос камеры в направлении выделенных элементов*/
    CenterViewOnSelected(): void;
}

/**Методы облета сцены */
interface IP3DBPlugin_Fly {
    GetFlybys(): string;
    SetFlyby(name: string): void;
    StartFlyBy(): void;
    PauseFlyBy(): void;
    SetFlyByPositon(percent: number): void;
}

/**Методы для работы с отдельными элементами сцены */
interface IP3DBPlugin_Elements {
    SelectElementGroups(groups: string, mode: SelectionMode): void;
    ResetSelection(): string;
    GetSelectedUIDs(): string;
    Selection_GetUID(index: number): number;
    Selection_GetPath(index: number): string;

    /**Возвращает количество выделенных элементов*/
    Selection_Count(): number;

    /**Получить предков
     * @param {number} uid UID объекта
     */
    GetAncestors(uid: number): string;
}

/**Утилиты плагина */
interface IP3DBPlugin_Utils {
    /**Отправляет сообщение в логи плагина*/
    SendToLog(message: string, isError: boolean): void;

    ProcessMessages(): void;
}

/**Флаги, событий мыши плагина */
export enum MouseEventFlags {
    Npl_MLP_MOUSE_DOWN = 1,
    Npl_MLP_MOUSE_MOVE = 2,
    Npl_MLP_MOUSE_UP = 3,
    Npl_MLP_MOUSE_LEFT = 1 << 4,
    Npl_MLP_MOUSE_RGHT = 2 << 4,
    Npl_MLP_MOUSE_MIDL = 4 << 4,
    Npl_MLP_MOUSE_DBCL = 8 << 4, // (v615) double-click, приходит на втором DOWN
    Npl_MLP_MOUSE_SHFT = 1 << 8,
    Npl_MLP_MOUSE_CTRL = 2 << 8,
    Npl_MLP_MOUSE_ALT = 4 << 8,
}

/**События выделения элементов в сцене */
export enum PickEventParam {
    Npl_MLP_PICK_INFO = 1, // (before/pass) атрибуты элемента
    Npl_MLP_PICK_ELM = 2, // выбор отдельного элемента (tool = info)
    Npl_MLP_PICK_BOX = 3, // выбор рамкой, прочие варианты выбора
    Npl_MLP_PICK_CLR = 8, // отмена выбора v501
}

export enum ToolEventParam {
    Npl_MLP_TOOL_START = 4, // запуск команды
    Npl_MLP_TOOL_RESET = 5, // сброс команды (step=0)
    Npl_MLP_TOOL_STEP = 6, // следующий шаг
    Npl_MLP_TOOL_POINT = 7, // точка привязки (tool = measure|redline)
}

/**События плагина */
export enum Plugin3DEvent {
    ContextMenuCommandExecuted = "ContextMenuCommandExecuted",
    ModelLoadingStateChanged = "ModelLoadingStateChanged",
    Click = "Click",
    DoubleClick = "DoubleClick",
    Npl_MSG_MOUSE = "Npl_MSG_MOUSE",
    Npl_MSG_PICK = "Npl_MSG_PICK",
    Npl_MSG_TOOL = "Npl_MSG_TOOL",
    On_p3db_selection = "On_p3db_selection",
    CacheLoadFromUriEvent = "CacheLoadFromUriEvent",
    SceneLoadFromCacheEvent = "SceneLoadFromCacheEvent",
    SceneLoadFromFileEvent = "SceneLoadFromFileEvent",
    CacheLoadFromUriProgressEvent = "CacheLoadFromUriProgressEvent",
}

export interface SelectionArgs {
    groups: SelectionGroup[];
    mode: SelectionMode;
}

export interface CameraViewArgs {
    position: {
        x: number;
        y: number;
        z: number;
    };
    view: {
        azimuth: number;
        zenith: number;
        fov: number;
    };
}

export enum P3dbInitializationState {
    Successful = 1,
    Failed = 2,
    Expired = 3, // срок лицензии истек
    Obsolete = 4, // версия плагина устарела (не соот. требуемой сайтом)
}

export enum P3dbLoadingState {
    Progress = 1,
    Loaded = 2,
    Failed = 3,
    Aborted = 4,
}

export enum P3DBSceneLoadMode {
    Npl_File_Open = 0, // - открыть файл в элемент с индексом 0 - рабочая область
    Npl_File_Merge = 1, //- объединить
    Npl_File_Insert = 2, // - вставить
    Npl_File_AsRef = 4, // - добавить дополнительный
    Npl_File_Dialog = 8, // - диалог
    Npl_File_NoRef = 16, // не загружать ref (для p3dw)
}

/**Состояние события */
export enum EventState {
    /**Ошибка */
    Error = -1,
    /**Поставлено в очередь */
    None = 0,
    /**Обрабатывается */
    InProcess = 1,
    /**Завершено */
    Complete = 2,
}

/**Информация о плагине */
export interface IPluginInformation {
    /**Наименование плагина */
    name: string;
    /**Версия плагина */
    version: string;
    /**Версия драйвера */
    driverVersion: string;

    /**Имя рендера (IV/IB) */
    renderName: string;
}

export interface IOpenFileDialogOptions {
    isMultiSelect: boolean;
    filters: [
        {
            name: string;
            mask: string;
        }
    ];
}

export interface IOpenFileDialogResult {
    path: string;
    size: number;
    createTimeUtc: string;
    lastChangeTimeUtc: string;
    name: string;
    extension: string;
}

export enum ViewColorType {
    Npl_View_CLR_BG0 = 30,
    Npl_View_CLR_BG1 = 31,
    Npl_View_CLR_SEL = 32,
    Npl_View_CLR_HLT = 33,
    Npl_View_CLR_FND = 34,
    Npl_View_CLR_RLN = 35,
}

export class ViewOptionsType {
    /**Освещение */
    static readonly Npl_View_LIGHT = 1;
    /**Face culling  */
    static readonly Npl_View_BKFCS = 2;
    static readonly Npl_View_BLEND = 3;
    static readonly Npl_View_TXTRS = 4;
    static readonly Npl_View_SPCLR = 5;
    static readonly Npl_View_ORTHO = 6;
    static readonly Npl_View_CLIP = 7;
    static readonly Npl_View_WRFRM = 8;
    static readonly Npl_View_EDGES = 9;
    static readonly Npl_View_AXES = 10;
    static readonly Npl_View_DROP = 11;
    static readonly Npl_View_ASPECT = 12;
    static readonly Npl_View_CPIDX = 13;
    static readonly Npl_View_NAVI = 20;
    /**план/перспектива */
    static readonly Npl_View_LOCK = 21;
    static readonly Npl_View_PAGE = 24;
}

export const P3DBPLUGIN_NAME_OBJECT = "p3db_AX_library.p3db_AX_form";
