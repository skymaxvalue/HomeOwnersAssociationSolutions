import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TowingCompanyHomePageComponent } from './towing-company-home-page.component';

describe('TowingCompanyHomePageComponent', () => {
  let component: TowingCompanyHomePageComponent;
  let fixture: ComponentFixture<TowingCompanyHomePageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TowingCompanyHomePageComponent]
    });
    fixture = TestBed.createComponent(TowingCompanyHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
