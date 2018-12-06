import { TestBed } from '@angular/core/testing';

import { WareouseApiService } from './warehouse-api.service';

describe('WareouseApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WareouseApiService = TestBed.get(WareouseApiService);
    expect(service).toBeTruthy();
  });
});
