import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { Observable } from 'rxjs';
import { ProductCart } from '../models/product-cart';
import { ProductToAdd } from '../models/product-to-add';
import { ProductToEdite } from '../models/product-to-edite';
import { ProductWishlist } from '../models/product-wishlist';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
baseurl="https://localhost:7191/api/Products";
  constructor(public http:HttpClient) { }
  //add product to database
  Add(newproduct: ProductToAdd, UserId: string): Observable<ProductToAdd> {
    // Define query parameters
    const params = new HttpParams().set('UserId', UserId.toString());

    // Define options for the POST request
    const options = {
      params: params
    };

    // Send the POST request
    return this.http.post<ProductToAdd>(this.baseurl, newproduct, options);
  }

  GetById(Id: number): Observable<Product> {
    // Construct the URL with the product ID
    const url = `${this.baseurl}/${Id}`;
    // Send the GET request to retrieve the product by its ID
    return this.http.get<Product>(url);
  }


  //get product Cart item
  GetProductCartById(Id: number): Observable<ProductCart> {
    // Construct the URL with the product ID
    const url = `${this.baseurl}/${Id}`;
    // Send the GET request to retrieve the product by its ID
    return this.http.get<ProductCart>(url);
  }


  //get product wislist item
  GetProductWishlistById(Id: number): Observable<ProductWishlist> {
    // Construct the URL with the product ID
    const url = `${this.baseurl}/${Id}`;
    // Send the GET request to retrieve the product by its ID
    return this.http.get<ProductWishlist>(url);
  }


  update(UpdatedProduct: ProductToEdite, Id: number): Observable<ProductToEdite> {
    const url = `${this.baseurl}/${Id}`;

    // Send the PATCH request
    return this.http.patch<ProductToEdite>(url, UpdatedProduct);
  }

  GetProductsByCategoryId(CategoryId: number): Observable<Product[]>{
    const url = `${this.baseurl}/categories/${CategoryId}`;
    return this.http.get<Product[]>(url);
   }

   GetAllProducts():Observable<Product[]>{
    const url =  `${this.baseurl}/getAll`;
    return this.http.get<Product[]>(url);
   }


   delete(Id:number){
    const url = `${this.baseurl}/${Id}`;

    return this.http.delete(url);

  }


}



