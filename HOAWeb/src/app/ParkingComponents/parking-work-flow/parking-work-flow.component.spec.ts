import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkingWorkFlowComponent } from './parking-work-flow.component';

describe('ParkingWorkFlowComponent', () => {
  let component: ParkingWorkFlowComponent;
  let fixture: ComponentFixture<ParkingWorkFlowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ParkingWorkFlowComponent]
    });
    fixture = TestBed.createComponent(ParkingWorkFlowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
