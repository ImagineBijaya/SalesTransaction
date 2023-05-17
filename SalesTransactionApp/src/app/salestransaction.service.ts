import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISalestransaction } from './salestransaction';
@Injectable({
  providedIn: 'root'
})
export class SalesTrasactionService {

  private _url:string ="https://localhost:44392/api/salestransaction/";
  httpOptions = {

    headers: new HttpHeaders({

      'Content-Type': 'application/json'

    })

  }
  constructor(private http: HttpClient) { }

  getsalestrasactions(): Observable<ISalestransaction[]>
  {
    return this.http.get<ISalestransaction[]>(this._url + "getsalestrasactionlist")
  }
  getsalestrasactionById(id:number):Observable<ISalestransaction>
  {
    return this.http.get<ISalestransaction>(this._url +"getsalestrasactionbyid/" +id)

  }
  addsalestrasaction(salestrasaction:ISalestransaction):Observable<any>{
      return this.http.post(this._url + "addsalestrasaction/" ,JSON.stringify(salestrasaction), this.httpOptions)
  }

  updatesalestrasaction(salestrasaction:ISalestransaction):Observable<any>{
     return this.http.put(this._url + "updatesalestrasaction/",JSON.stringify(salestrasaction),this.httpOptions)
  }

  delete(id:number){

    return this.http.delete(this._url + '/deletesalestrasaction/' + id, this.httpOptions)

  }

}
