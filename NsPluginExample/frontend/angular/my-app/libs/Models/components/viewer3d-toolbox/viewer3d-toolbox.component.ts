import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-viewer3d-toolbox',
  templateUrl: './viewer3d-toolbox.component.html',
  styleUrls: ['./viewer3d-toolbox.component.scss']
})
export class Viewer3dToolboxComponent implements OnInit {
  @Input() disabled: boolean;

  private _restricted: boolean;
  /**Ограниченный режим */
  @Input() set restricted(value: boolean) {
    this._restricted = value;
    this.init();
  }
  get restricted() {
    return this._restricted;
  }

  @Output() commandClick: EventEmitter<IToolboxClickEvent> = new EventEmitter();

  buttons: IToolboxButton[];

  constructor() { }

  ngOnInit() {
    this.init();
  }

  clickHandler(index: number, button: IToolboxButton) {
    this.commandClick.emit({ index, button });
  }

  private init() {
    this.buttons = [
      {
        name: 'tree',
        icon: 'mdi mdi-file-tree mdi-24px',
        title: "Открыть дерево моделей",
        invisible: this.restricted
      },
      {
        name: 'openFiles',
        icon: 'mdi mdi-folder-open mdi-24px',
        title: 'Загрузить из файла ...',
        invisible: this.restricted
      }
      , {
        name: 'addFiles',
        icon: 'mdi mdi-playlist-plus mdi-24px',
        title: 'Добавить к сцене ...'
      },
      {
        name: 'removeFiles',
        icon: 'mdi mdi-playlist-minus mdi-24px',
        title: 'Удалить из сцены ...'
      },
      {
        name: 'clearScene',
        icon: 'mdi mdi-close mdi-24px',
        title: 'Очистить сцену'
      },
      {
        name: 'toggleGUI',
        icon: 'mdi mdi-settings mdi-24px',
        title: 'Показать/Скрыть инструменты плагина'
      },
      {
        name: 'crosshairs',
        icon: 'mdi mdi-crosshairs mdi-24px',
        title: 'По центру сцены'
      },
      {
        name: 'showAll',
        icon: 'mdi mdi-eye mdi-24px',
        value: 0,
        title: 'Показать все'
      },
      {
        name: 'hide',
        icon: 'mdi mdi-eye-off mdi-24px',
        value: 1,
        title: 'Скрыть'
      },
      {
        name: 'fade',
        icon: 'mdi mdi-box-shadow mdi-24px',
        value: 2,
        title: 'Затенить'
      },
      {
        name: 'clip',
        icon: 'mdi mdi-content-cut mdi-24px',
        value: 3,
        title: 'Сечения'
      }
    ];
  }
}

/**Описание кнопки */
export interface IToolboxButton {
  name: string;
  icon: string;
  value?: any;
  title?: string;
  invisible?: boolean;
}

/** Событие о клике по кнопке тубокса*/
export interface IToolboxClickEvent {
  index: number;
  button: IToolboxButton;
}
