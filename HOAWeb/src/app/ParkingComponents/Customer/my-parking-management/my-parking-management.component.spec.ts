import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyParkingManagementComponent } from './my-parking-management.component';

describe('MyParkingManagementComponent', () => {
  let component: MyParkingManagementComponent;
  let fixture: ComponentFixture<MyParkingManagementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyParkingManagementComponent]
    });
    fixture = TestBed.createComponent(MyParkingManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
