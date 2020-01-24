/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Viewer3dFileListComponent } from './viewer3d-file-list.component';

describe('Viewer3dFileListComponent', () => {
  let component: Viewer3dFileListComponent;
  let fixture: ComponentFixture<Viewer3dFileListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Viewer3dFileListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Viewer3dFileListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
