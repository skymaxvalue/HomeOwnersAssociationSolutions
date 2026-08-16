import { TestBed } from '@angular/core/testing';

import { MyParkingManagementService } from './my-parking-management.service';

describe('MyParkingManagementService', () => {
  let service: MyParkingManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MyParkingManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
