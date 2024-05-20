import { HttpClient ,HttpHeaders, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cart } from '../models/cart';
import { CartItem } from '../models/cart-item';
import { AccountService } from './account.service';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  private baseUrl = 'https://localhost:7191/api/Cart';
  private baseUrl2 = 'https://localhost:7191/api/CartItem'

  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) { }

// addTocart(cartId:string,cartItem:CartItem):Observable<CartItem>{
//   const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
//   const params = new HttpParams().set('cartId', cartId.toString());
//   const options = {
//     headers,
//     params
//   };
//   return this.http.post<CartItem>(`${this.baseUrl2}`, { headers, body: cartItem },options);
// }


addTocart(cartId: string, cartItem: CartItem): Observable<CartItem> {
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  const params = new HttpParams().set('cartId', cartId);
  const options = {
    headers,
    params
  };
  return this.http.post<CartItem>(`${this.baseUrl2}`, cartItem, options);
}


  getCartById(Id: string): Observable<Cart> {
    return this.http.get<Cart>(`${this.baseUrl}/${Id}`);
  }

  update(UpdatedcartItem: CartItem, Id: string): Observable<CartItem> {
    const url = `https://localhost:7191/api/CartItem/${Id}`;
    return this.http.patch<CartItem>(url, UpdatedcartItem);
  }

  delete(UpdatedcartItem: CartItem, Id: string){
    const url = `https://localhost:7191/api/CartItem/${Id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.delete(url, { headers, body: UpdatedcartItem });  }
}
