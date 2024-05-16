import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cart } from '../models/cart';
import { AccountService } from './account.service';
import { CartItem } from '../models/cart-item';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http:HttpClient,private accountservice:AccountService) { }

  baseUrl="https://localhost:7191/api/Cart";
  getCartById(Id:string){

    // const Id=this.accountservice.claims?.UserId;

    return this.http.get<Cart>(`${this.baseUrl}/${Id}`);

  }


  update(UpdatedcartItem: CartItem, Id: string): Observable<CartItem> {
    const url = `https://localhost:7191/api/CartItem/${Id}`;

    // Send the PATCH request
    return this.http.patch<CartItem>(url, UpdatedcartItem);
  }

  delete(UpdatedcartItem: CartItem, Id: string){
    const url = `https://localhost:7191/api/CartItem/${Id}`;
    return this.http.delete(url);
  }

}
