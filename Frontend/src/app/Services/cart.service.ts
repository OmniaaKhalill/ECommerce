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
  
  
  //getbyId
  getCartById(Id:string)
  {
    // const Id=this.accountservice.claims?.UserId;

    return this.http.get<Cart>(`${this.baseUrl}/${Id}`);

  }

//update quentity
  update(UpdatedcartItem: CartItem, Id: string): Observable<CartItem> 
  {
    const url = `https://localhost:7191/api/CartItem/${Id}`;

    // Send the PATCH request
    return this.http.patch<CartItem>(url, UpdatedcartItem);
  }
  delete(cartItem: CartItem, cartId: string): Observable<Cart> {
    const url = `https://localhost:7191/api/CartItem/${cartId}`;
    return this.http.request<Cart>('delete', url, { body: cartItem });
  }

}
