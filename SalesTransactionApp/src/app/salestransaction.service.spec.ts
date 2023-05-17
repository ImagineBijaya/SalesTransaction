import { TestBed } from '@angular/core/testing';

import { SalestransactionService } from './salestransaction.service';

describe('SalestransactionService', () => {
  let service: SalestransactionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalestransactionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
