import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cart } from '../models/cart';
import { CartItem } from '../models/cart-item';
import { AccountService } from './account.service'; // Ensure correct casing

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private baseUrl = 'https://localhost:7191/api/Cart';

  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) { }

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
