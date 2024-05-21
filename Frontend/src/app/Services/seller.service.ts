import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { Seller } from '../models/seller';

@Injectable({
  providedIn: 'root'
})
export class SellerService {

  baseurl="https://localhost:7191/api/Sellers";
  constructor(public http:HttpClient) { }



  AddSeller(newseller: Seller): Promise<boolean>{
    let str: string = `/AddSeller`;
  
    return new Promise<boolean>((resolve) => {
      this.http.post(this.baseurl + str, newseller, { responseType: 'text' }).subscribe(
        (response) => {
          localStorage.removeItem("token");
          localStorage.setItem("token", response);

          resolve(true); 
        },
        (error) => {
          console.error("Error occurred during registration:", error);
          resolve(false); 
        }
      );
    });
  }

  getSellerByUserId(userId:string):Observable<Seller>{
    const url = `${this.baseurl}/getSeller/${userId}`;
    return this.http.get<Seller>(url);
  }
 
}
