import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule ,routingComponents} from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { NavbarComponent } from './navbar/navbar.component';
import {  HttpClientModule } from '@angular/common/http';
import { CustomerDetailsComponent } from './customer-details/customer-details.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { SalestransactionDetailsComponent } from './salestransaction-details/salestransaction-details.component';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    routingComponents,
    CustomerDetailsComponent,
    ProductDetailsComponent,
    SalestransactionDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
