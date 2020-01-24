import { Component, OnInit } from '@angular/core';

/**Компонент-секция для работы с панорамами */
@Component({
  selector: 'my-app-panorams',
  templateUrl: './panorams.component.html',
  styleUrls: ['./panorams.component.scss']
})
export class PanoramsComponent implements OnInit {

  /**Выдленная панорама */
  selectedPanoram: any;

  constructor() { }

  ngOnInit() {
  }

  /**Реация на выбор текущей панорамы */
  panoramSelectionChangeHandler(panoram: any) {
    this.selectedPanoram = panoram;
  }
}
