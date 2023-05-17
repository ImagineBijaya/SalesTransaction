import { Component, OnInit } from '@angular/core';
import { SalesTrasactionService } from '../salestransaction.service';
import { ActivatedRoute,Router } from '@angular/router';
import { Location } from '@angular/common';
import { ISalestransaction } from '../salestransaction';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-salestransaction-details',
  templateUrl: './salestransaction-details.component.html',
  styleUrls: ['./salestransaction-details.component.css']
})
export class SalestransactionDetailsComponent  implements OnInit{

  public id: number=-1;
  public isAddMode =false;
  public loading = false;
  public submitted = false;
  public  salestransaction :any=[];
  constructor(
    private formBuilder:FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private _salesTransactionService: SalesTrasactionService,
    private location:Location
  ) {}

  public form: FormGroup = this.formBuilder.group({
    salesTransactionId:[Number],
    customerId: ['', Validators.required],
    productId: ['', Validators.required],
    qunatity: ['', Validators.required],
    amount:['', Validators.required],
    invoice:[Boolean]
  })

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.isAddMode = !this.id;
    if (!this.isAddMode) {
      this.getsalesTransaction();
      }
  }

  getsalesTransaction(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this._salesTransactionService.getsalestrasactionById(id)
      .subscribe(data=> this.salestransaction = data);
  }
  // goBack(): void {
  //   this.location.back();
  // }
  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.form.invalid) {
        return;
    }

    this.loading = true;
    if (this.isAddMode) {
        this.createSalestransaction();
    } else {
        this.updateSalestransaction();
    }
}

private createSalestransaction() {
    this._salesTransactionService.addsalestrasaction(this.form.value)
        .pipe(first())
        .subscribe({
            next: () => {
                // this.alertService.success('User added', { keepAfterRouteChange: true });
                this.router.navigate(['../'], { relativeTo: this.route });
            },
            error: error => {
                // this.alertService.error(error);
                this.loading = false;
            }
        });
}

private updateSalestransaction() {
    this._salesTransactionService.updatesalestrasaction( this.form.value)
        .pipe(first())
        .subscribe({
            next: () => {
                // this.alertService.success('User updated', { keepAfterRouteChange: true });
                this.router.navigate(['../../'], { relativeTo: this.route });
            },
            error: error => {
                // this.alertService.error(error);
                this.loading = false;
            }
        });
}
}
