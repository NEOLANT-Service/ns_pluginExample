/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PanoramsListComponent } from './panorams-list.component';

describe('PanoramsListComponent', () => {
  let component: PanoramsListComponent;
  let fixture: ComponentFixture<PanoramsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PanoramsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PanoramsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
