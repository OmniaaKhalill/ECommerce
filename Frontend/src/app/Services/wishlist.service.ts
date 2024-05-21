import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Wishlist } from '../models/wishlist';
import { WishlistItem } from '../models/wishlist-item';

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private baseUrl = 'https://localhost:7191/api/Wishlist';
  private baseUrl2 = 'https://localhost:7191/api/WishlistItem';

  constructor(private http: HttpClient) { }

  AddWishlistItem(wishlistId: string, wishlistItem: WishlistItem): Observable<WishlistItem> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const params = new HttpParams().set('wishlistId', wishlistId);
    const options = {
      headers,
      params
    };

    console.log("AddWishlistItem called with:");
    console.log("wishlistId:", wishlistId);
    console.log("wishlistItem:", wishlistItem);

    return this.http.post<WishlistItem>(`${this.baseUrl2}`, wishlistItem, options);
  }

  GetWishlistById(id: string): Observable<Wishlist> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<Wishlist>(url);
  }

  DeleteWishlist(wishlistItem: WishlistItem, wishlistId: string): Observable<void> {
    console.log("Delete02");
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    console.log("Delete03");
    const params = new HttpParams().set('wishlistId', wishlistId);
    console.log("Delete04");
    const options = {
      headers,
      params,
      body: wishlistItem
    };
    console.log("Delete05");
    return this.http.delete<void>(this.baseUrl2, options);
  }
}

