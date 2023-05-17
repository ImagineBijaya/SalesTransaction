import { Component } from '@angular/core';
import { CustomerService } from '../customer.service';
import { ActivatedRoute,Router } from '@angular/router';
import { Location } from '@angular/common';
import { IProduct } from '../product';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators'

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent {
  public id: number=-1;
  public isAddMode =false;
  public loading = false;
  public submitted = false;
  public  customer :any=[];

  constructor(
    private formBuilder:FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private _customerService: CustomerService,
    private location:Location
  ) {}
  public form: FormGroup = this.formBuilder.group({
    cutomerId: [Number],
    customerName: ['', Validators.required],
    customerAddress: ['', Validators.required],
    phoneNumber: ['', Validators.required]
  })
  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.isAddMode = !this.id;
    if (!this.isAddMode) {
      this.getCustomer();
      }
  }
  getCustomer(): void {
    this._customerService.getcustomerById(this.id)
      .subscribe(data=> this.customer = data);
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
        this.createCustomer();
    } else {
        this.updateCustomer();
    }
}

private createCustomer() {
    this._customerService.addCustomer(this.form.value)
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

private updateCustomer() {
    this._customerService.updateCustomer( this.form.value)
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
