import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProduct } from './product';



@Injectable({
  providedIn: 'root'
})

export class ProductService {

  private _url:string ="https://localhost:44392/api/product/";
  httpOptions = {

    headers: new HttpHeaders({

      'Content-Type': 'application/json'

    })

  }
  constructor(private http: HttpClient) { }

  getproducts(): Observable<IProduct[]>
  {
    return this.http.get<IProduct[]>(this._url + "getproductlist")
  }
  getproductById(id:number):Observable<IProduct>
  {
    return this.http.get<IProduct>(this._url +"getproductbyid/" +id)

  }
  addProduct(product:IProduct):Observable<any>{
      return this.http.post(this._url + "addproduct/" ,JSON.stringify(product), this.httpOptions)
  }

  updateProduct(product:IProduct):Observable<any>{
     return this.http.put(this._url + "updateproduct/",JSON.stringify(product),this.httpOptions)
  }

  delete(id:number){

    return this.http.delete(this._url + '/deleteproduct/' + id, this.httpOptions)

  }

}

