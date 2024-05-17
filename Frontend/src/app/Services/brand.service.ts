import { Brands } from '../models/brands';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  private baseurl = "https://localhost:7191/api/Shop/brands";
  constructor(public http: HttpClient) { }
  GetBrands(): Observable<Brands[]> {
    return this.http.get<Brands[]>(this.baseurl);
  }
}
