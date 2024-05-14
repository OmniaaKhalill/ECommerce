import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private baseurl = "https://localhost:7191/api/Shop/categories";
  constructor(public http: HttpClient) { }
  GetCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseurl);
  }
}
