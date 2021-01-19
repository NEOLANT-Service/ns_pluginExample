import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";

export class P3DBPluginWrapperUI {
    constructor(private readonly wrapper: IP3DBPluginWrapper) {

    }

    /**Добавляет элемент контекстного меню */
    addContextMenu(menu: IContextMenu) {
        const str = this.wrapper.toJSON(menu);
        this.wrapper.plugin.AddContextMenuCommands(str);
    }

    /**Видимость элементов управления p3d. Параметры принимают 1 или 0.
        * @param menu - видимость меню
        * @param toolbar - видимость элементов toolbar
        * @param statusbar - видимость statusbar (нижняя панель)
        * @param toolpad видимость toolpad
        */
    setControlsVisible(menu: number, toolbar: number, statusbar: number, toolpad: number) {
        this.wrapper.plugin.ApiControlsVisible(menu, toolbar, statusbar, toolpad);
    }
}

export interface IContextMenu {
    Group: string;
    Commands: { Id: string, Name: string }[]
}