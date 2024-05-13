import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseurl = "https://localhost:7191/api/Shop";
  constructor(public http:HttpClient) { }

  GetProducts() {
    this.http.get<Product[]>(this.baseurl).subscribe({
      next:(data) => console.log(data),
      error:(err) => console.log(err),
      complete:() => console.log("Completed")
    });
  }
}
