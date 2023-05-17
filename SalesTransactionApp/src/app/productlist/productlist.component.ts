import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit {

public  products:any[]=[];

constructor(private _productservice:ProductService){}

ngOnInit()  {
  this._productservice.getproducts().subscribe(data => this.products = data);
}
displayedColumns: string[] = ['Id', 'Name', 'Unit', 'Price','Action'];
dataSource = this.products;
delete(id:number){

  this._productservice.delete(id);

  }
}
