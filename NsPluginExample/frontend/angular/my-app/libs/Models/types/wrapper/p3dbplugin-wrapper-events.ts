import { IP3DBPluginWrapper } from "./p3dbplugin-wrapper.types";
import { Subject } from "rxjs";
import { P3dbInitializationState, Plugin3DEvent, MouseEventFlags, PickEventParam, P3dbLoadingState } from "../p3dbplugin.type";
import { P3DBPluginDblClickManager } from "./dblclick-manager";


export class P3DBPluginWrapperEvents {
    initializationComplete: Subject<{ state: P3dbInitializationState, error?: string }> = new Subject();
    loadingProgressChanged: Subject<{ state: P3dbLoadingState, total?: number, loaded?: number, error?: string }> = new Subject();
    contextMenuClick: Subject<number> = new Subject();
    click: Subject<void> = new Subject();
    doubleClick: Subject<void> = new Subject();
    selectedChanged: Subject<number[]> = new Subject();
    loadingProcess: Subject<void> = new Subject();

    private _dblClickManager: P3DBPluginDblClickManager = new P3DBPluginDblClickManager();
    private _selectionTimer: any;

    constructor(private readonly wrapper: IP3DBPluginWrapper) {
        this._init();
    }

    destruct() {
        this.wrapper.removeEvent(Plugin3DEvent.ContextMenuCommandExecuted, this._contextMenuClickHandler);
        this.wrapper.removeEvent(Plugin3DEvent.Npl_MSG_MOUSE, this._mouseEventHandler);
        this.wrapper.removeEvent(Plugin3DEvent.Npl_MSG_PICK, this._selectedChangeHandler);
    }

    private _init() {
        this.wrapper.addEvent(Plugin3DEvent.ContextMenuCommandExecuted, this._contextMenuClickHandler);
        this.wrapper.addEvent(Plugin3DEvent.Npl_MSG_MOUSE, this._mouseEventHandler);
        this.wrapper.addEvent(Plugin3DEvent.Npl_MSG_PICK, this._selectedChangeHandler);
    }

    private _contextMenuClickHandler = (e: CustomEvent) => {
        const [id] = e.detail;
        this.contextMenuClick.next(id);
    }

    private _mouseEventHandler = (e: CustomEvent) => {
        const [flags] = e.detail;
        if ((flags & MouseEventFlags.Npl_MLP_MOUSE_UP) === MouseEventFlags.Npl_MLP_MOUSE_UP) {
            if ((flags & MouseEventFlags.Npl_MLP_MOUSE_LEFT) === MouseEventFlags.Npl_MLP_MOUSE_LEFT) {
                this.click.next();
            }
        }
        if ((flags & MouseEventFlags.Npl_MLP_MOUSE_DBCL) === MouseEventFlags.Npl_MLP_MOUSE_DBCL) {
            this._dblClickManager.check();
            this.doubleClick.next();
        }
    }

    private _selectedChangeHandler = (e: CustomEvent) => {
        const [eventArg] = e.detail;
        this._dblClickManager.begin()
            .then(() => {
                switch (eventArg) {
                    case PickEventParam.Npl_MLP_PICK_CLR:
                    case PickEventParam.Npl_MLP_PICK_ELM:
                    case PickEventParam.Npl_MLP_PICK_BOX:
                        //Таймер устанавливается, потому-что при выделении зачем-то сначала присылается сообщение о снятии выделения
                        if (this._selectionTimer === undefined)
                            this._selectionTimer = setTimeout(() => {
                                clearTimeout(this._selectionTimer);
                                this._selectionTimer = undefined;
                                let uids = this.wrapper.selection.getSelectedUIDs();
                                if (uids === undefined) uids = [];
                                this.selectedChanged.next(uids);
                            }, SELECTION_DELAY)
                        break;
                }
            })
    }
}

const SELECTION_DELAY = 50;