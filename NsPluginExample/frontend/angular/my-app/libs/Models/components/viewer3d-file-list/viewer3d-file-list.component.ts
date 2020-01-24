import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-viewer3d-file-list',
  templateUrl: './viewer3d-file-list.component.html',
  styleUrls: ['./viewer3d-file-list.component.css']
})
export class Viewer3dFileListComponent implements OnInit {
  @Input() files: any[];

  @Output() commit: EventEmitter<any[]> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }
}
