import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductsPaginationReadDto } from '../models/products-pagination-read-dto';
import { Product } from '../models/product';
import { ProductRead } from '../models/product-read';

@Injectable({
  providedIn: 'root'
})
export class SellerProductsService {

  constructor(public http:HttpClient) { }

  beseUrl="https://localhost:7191/GetProductsPagenation"
  getSellerProducts(UserId:string,page:number,countPerPage:number):Observable<ProductsPaginationReadDto >
  {

    
    return this.http.get<ProductsPaginationReadDto>(`${this.beseUrl}/${UserId}/${page}/${countPerPage}`)
  }
}
