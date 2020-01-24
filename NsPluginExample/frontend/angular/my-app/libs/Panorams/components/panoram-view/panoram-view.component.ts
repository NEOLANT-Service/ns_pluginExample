import { IPanoram } from './../../services/backend/panorams.service';
import { Component, OnInit, Input, ViewChild, AfterViewInit } from '@angular/core';

/**Компонент для просмотра панорамы
 *
 * @Input panoram - Панорама, которую необходимо отобразить
 */
@Component({
  selector: 'app-panoram-view',
  templateUrl: './panoram-view.component.html',
  styleUrls: ['./panoram-view.component.scss']
})
export class PanoramViewComponent implements OnInit, AfterViewInit {

  private _panoram: IPanoram;
  @Input() set panoram(value: IPanoram) {
    this._panoram = value;
    this.fetchPanoramContent();
  }
  get panoram() { return this._panoram; }

  @ViewChild("iframeRef", { static: false }) iframe: { nativeElement: HTMLIFrameElement }
  constructor() { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.fetchPanoramContent();
  };

  /**Прлучение точки входа для панорамы */
  private fetchPanoramContent() {
    if (this.iframe) {
      if (this._panoram) {
        this.iframe.nativeElement.src = `/api/panorams/${this.panoram.Id}/content//${this.panoram.Entry}`
      } else {
        this.iframe.nativeElement.src = "about:blank";
      }
    }
  }
}
