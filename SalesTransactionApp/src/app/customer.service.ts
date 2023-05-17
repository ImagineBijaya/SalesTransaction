import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICustomer } from './customer';
@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private _url:string ="https://localhost:44392/api/customer/";
  httpOptions = {

    headers: new HttpHeaders({

      'Content-Type': 'application/json'

    })

  }
  constructor(private http: HttpClient) { }

  getcustomers(): Observable<ICustomer[]>
  {
    return this.http.get<ICustomer[]>(this._url + "getcustomerlist")
  }
  getcustomerById(id:number):Observable<ICustomer>
  {
    return this.http.get<ICustomer>(this._url +"getcustomerbyid/" +id)

  }
  addCustomer(customer:ICustomer):Observable<any>{
      return this.http.post(this._url + "addcustomer/" ,JSON.stringify(customer), this.httpOptions)
  }

  updateCustomer(customer:ICustomer):Observable<any>{
     return this.http.put(this._url + "updatecustomer/",JSON.stringify(customer),this.httpOptions)
  }

  delete(id:number){

    return this.http.delete(this._url + '/deletecustomer/' + id, this.httpOptions)

  }

}
