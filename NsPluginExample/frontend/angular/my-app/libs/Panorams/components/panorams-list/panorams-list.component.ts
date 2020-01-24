import { PanoramsService } from './../../services/backend/panorams.service';
import { Component, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

/**Компонент для отображения списка панорам
 *
 * @Output selectionChange - Событие о изменении текущего тура
*/
@Component({
  selector: 'app-panorams-list',
  templateUrl: './panorams-list.component.html',
  styleUrls: ['./panorams-list.component.scss']
})
export class PanoramsListComponent implements OnInit, OnDestroy {

  @Output() selectionChange: EventEmitter<any> = new EventEmitter();

  private ngUnsubscribe: Subject<void> = new Subject();
  panorams: any[];
  selectedPanoram: any;

  constructor(private panoramsService: PanoramsService) { }

  ngOnInit() {
    this.fetch()
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.unsubscribe();
  }

  /**Получение списка панорам */
  fetch() {
    this.panoramsService.getAll()
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: x => {
          this.panorams = x;
        }
      });
  }

  /**Реация на изменение текущей панорамы */
  protected selectionChangeHandler(panoram: any) {
    this.selectedPanoram=panoram;
    this.selectionChange.emit(this.selectedPanoram);
  }
}
