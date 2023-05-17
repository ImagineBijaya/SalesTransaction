import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalestransactionlistComponent } from './salestransactionlist.component';

describe('SalestransactionlistComponent', () => {
  let component: SalestransactionlistComponent;
  let fixture: ComponentFixture<SalestransactionlistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SalestransactionlistComponent]
    });
    fixture = TestBed.createComponent(SalestransactionlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
