import { Component, OnInit, Input } from '@angular/core';

/**Компонент верхнего меню
 *
 * @Input full - Признак показа полного меню
*/
@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent implements OnInit {
  @Input() full: boolean;

  menuItems: IMenuItem[];
  title = 'NEOSYNTEZ Examples';
  constructor() { }

  ngOnInit() {
    this.initMenu();
  }

  private initMenu() {
    this.menuItems = [
      {
        name: "Модели",
        url: '/models',
        icon: "mdi mdi-cube"
      }
      , {
        name: 'Панорамы',
        url: "/panorams",
        icon: "mdi mdi-panorama"
      }

    ];
  }
}

interface IMenuItem {
  name: string;
  url: string;
  icon: string;

}

