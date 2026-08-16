import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HOAHomePageComponent } from './hoahome-page.component';

describe('HOAHomePageComponent', () => {
  let component: HOAHomePageComponent;
  let fixture: ComponentFixture<HOAHomePageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HOAHomePageComponent]
    });
    fixture = TestBed.createComponent(HOAHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
