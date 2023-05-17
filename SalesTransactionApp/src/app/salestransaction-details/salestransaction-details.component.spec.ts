import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalestransactionDetailsComponent } from './salestransaction-details.component';

describe('SalestransactionDetailsComponent', () => {
  let component: SalestransactionDetailsComponent;
  let fixture: ComponentFixture<SalestransactionDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SalestransactionDetailsComponent]
    });
    fixture = TestBed.createComponent(SalestransactionDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
