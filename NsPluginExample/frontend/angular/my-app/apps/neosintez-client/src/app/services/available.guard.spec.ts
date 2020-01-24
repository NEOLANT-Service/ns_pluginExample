/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AvailableGuard } from './available.guard'

describe('Service: AvailableGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AvailableGuard]
    });
  });

  it('should ...', inject([AvailableGuard], (service: AvailableGuard) => {
    expect(service).toBeTruthy();
  }));
});
