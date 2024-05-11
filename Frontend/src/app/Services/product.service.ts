import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
baseurl="https://localhost:7191/api/Products";
  constructor(public http:HttpClient) { }
//getAll,getById,Update,Delete,Add
Add(newproduct:Product)
{

return this.http.post<Product>(this.baseurl,newproduct);  
}




}
