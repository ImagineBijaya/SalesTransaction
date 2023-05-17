import { Component,OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
@Component({
  selector: 'app-customerlist',
  templateUrl: './customerlist.component.html',
  styleUrls: ['./customerlist.component.css']
})
export class CustomerlistComponent implements OnInit {
  public  customers :any[]=[];

  constructor(private _customerservice:CustomerService){}

  ngOnInit()  {
    this._customerservice.getcustomers().subscribe(data => this.customers = data);
  }
  displayedColumns: string[] = ['Id', 'Name', 'Address', 'Phone','Action'];
  dataSource = this.customers;
  delete(id:number){

    this._customerservice.delete(id);

    }
}
