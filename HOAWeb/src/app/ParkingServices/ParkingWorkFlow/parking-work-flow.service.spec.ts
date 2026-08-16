import { TestBed } from '@angular/core/testing';

import { ParkingWorkFlowService } from './parking-work-flow.service';

describe('ParkingWorkFlowService', () => {
  let service: ParkingWorkFlowService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParkingWorkFlowService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
