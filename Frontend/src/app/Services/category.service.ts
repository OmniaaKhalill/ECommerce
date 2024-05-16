import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private baseurl = "https://localhost:7191/api/Shop/categories";
  private baseUrl = "https://localhost:7191/api/Shop/categories";
  constructor(public http: HttpClient) { }
  GetCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseurl);
  }

  GetProductsByCategory(categoryId: number): Observable<Product[]> {
    const url = `${this.baseUrl}/${categoryId}`;
    return this.http.get<Product[]>(url);
  }
}
