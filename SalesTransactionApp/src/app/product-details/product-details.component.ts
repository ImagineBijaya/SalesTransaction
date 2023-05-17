import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { ActivatedRoute ,Router} from '@angular/router';
import { Location } from '@angular/common';
import { IProduct } from '../product';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit  {

   public id: number=-1;
   public isAddMode =false;
   public loading = false;
   public submitted = false;
  public  product :any=[];

  constructor(
    private formBuilder:FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private _productService: ProductService,
    private location:Location
  ) {}
  public form: FormGroup = this.formBuilder.group({
    id: [Number],
    productName: ['', Validators.required],
    productUnit: ['', Validators.required],
    productPrice: ['', Validators.required]
  })

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.isAddMode = !this.id;
    if (!this.isAddMode) {
      this.getProduct();
      }
  }

  getProduct(): void {
    this._productService.getproductById(this.id)
      .subscribe(data=> this.product = data);
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
        this.createProduct();
    } else {
        this.updateProduct();
    }
}

private createProduct() {
    this._productService.addProduct(this.form.value)
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

private updateProduct() {
    this._productService.updateProduct( this.form.value)
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
