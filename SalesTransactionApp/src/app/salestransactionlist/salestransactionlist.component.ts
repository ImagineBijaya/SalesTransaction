import { Component,OnInit } from '@angular/core';
import { SalesTrasactionService } from '../salestransaction.service';
@Component({
  selector: 'app-salestransactionlist',
  templateUrl: './salestransactionlist.component.html',
  styleUrls: ['./salestransactionlist.component.css']
})
export class SalestransactionlistComponent implements OnInit {

  public  salestransactions:any[]=[];

  constructor(private _salestransactionservice:SalesTrasactionService){}


ngOnInit()  {
  this._salestransactionservice.getsalestrasactions().subscribe(data => this.salestransactions = data);
}
displayedColumns: string[] = ['Id', 'Product', 'Customer', 'Quantity','Amount','Invoice','Action'];
dataSource = this.salestransactions;
delete(id:number){

  this._salestransactionservice.delete(id);

  }
}
