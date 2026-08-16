import { TestBed } from '@angular/core/testing';

import { APIUrlService } from './apiurl.service';

describe('APIUrlService', () => {
  let service: APIUrlService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(APIUrlService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
