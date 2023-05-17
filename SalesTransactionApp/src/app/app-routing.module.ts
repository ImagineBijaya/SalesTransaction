import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerlistComponent } from './customerlist/customerlist.component';
import { ProductlistComponent } from './productlist/productlist.component';
import { SalestransactionlistComponent } from './salestransactionlist/salestransactionlist.component';
import { CustomerDetailsComponent } from './customer-details/customer-details.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { SalestransactionDetailsComponent } from './salestransaction-details/salestransaction-details.component';
const routes: Routes = [
  { path:'customers',component:CustomerlistComponent},
  { path: 'createcustomer', component: CustomerDetailsComponent  },
  { path: 'editcustomer/:id', component: CustomerDetailsComponent },
  { path:'products', component:ProductlistComponent},
  { path: 'createproduct', component: ProductDetailsComponent  },
  { path: 'editproduct/:id', component: ProductDetailsComponent },
  { path:'salestransactions',component:SalestransactionlistComponent },
  { path: 'createsalestransaction', component: SalestransactionDetailsComponent  },
  { path: 'editsalestransaction/:id', component: SalestransactionDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents =[ProductlistComponent,CustomerlistComponent,SalestransactionlistComponent,ProductDetailsComponent,
CustomerDetailsComponent,SalestransactionDetailsComponent]
