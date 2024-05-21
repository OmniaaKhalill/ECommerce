import { Brands } from '../models/brands';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  private baseurl = "https://localhost:7191/api/Shop/brands";
  private baseUrl = "https://localhost:7191/api/Shop/brands";
  constructor(public http: HttpClient) { }
  GetBrands(): Observable<Brands[]> {
    return this.http.get<Brands[]>(this.baseurl);
  }

  GetProductsByBrand(brandsid: number): Observable<Product[]> {
    const url = `${this.baseUrl}/${brandsid}`;
    return this.http.get<Product[]>(url);
  }
}
