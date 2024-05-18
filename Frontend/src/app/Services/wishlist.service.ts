import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { WishlistItem } from '../models/wishlist-item';
import { Observable } from 'rxjs';
import { Wishlist } from '../models/wishlist';

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private baseUrl = 'https://localhost:7191/api/Wishlist';
  private baseUrl2 = 'https://localhost:7191/api/WishlistItem'
  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) { }


  AddWishlistItem(wishlistId: string, wishlistItem: WishlistItem): Observable<WishlistItem> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const params = new HttpParams().set('wishlistId', wishlistId);
    const options = {
      headers, params
    };
    return this.http.post<WishlistItem>(`${this.baseUrl2}`, wishlistId, options);
  }

  GetWishlistById(Id: string):Observable<Wishlist> {
    return this.http.get<Wishlist>(`${this.baseUrl}/${Id}`);
  }

  DeleteWishlist(wishlistItem: WishlistItem, Id: string) {
    const url = `${this.baseUrl2}/${Id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.delete(url, { headers, body:wishlistItem });
  }
}
