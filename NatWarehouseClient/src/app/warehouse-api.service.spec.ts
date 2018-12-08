import { TestBed } from '@angular/core/testing';

import { WarehouseApiService } from './warehouse-api.service';

describe('WareouseApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WarehouseApiService = TestBed.get(WarehouseApiService);
    expect(service).toBeTruthy();
  });
});
