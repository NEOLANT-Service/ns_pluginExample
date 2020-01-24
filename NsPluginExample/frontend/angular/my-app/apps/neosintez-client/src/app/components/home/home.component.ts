import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  constructor(private activatedRoute: ActivatedRoute) {

  }

  ngOnInit() {
    const objectId = this.activatedRoute.snapshot.queryParams['objectId'];
  }

  ngOnDestroy() { }
}
