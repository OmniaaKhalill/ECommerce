import { Injectable } from '@angular/core';
import { ShopParams } from '../models/shop-params';
import { HttpClient, HttpParams } from '@angular/common/http';
import { of, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Pagination } from '../models/pagination';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = "https://localhost:7191/api/Shop";
  constructor(public http: HttpClient) { }

  shopParams = new ShopParams();
  productCache = new Map<string, Pagination>();
  pagination = new Pagination();

  getProducts(useCache: boolean): Observable<Pagination> {
    if (useCache === false) {
      this.productCache.clear();
    }

    const cacheKey = Object.values(this.shopParams).join('-');
    if (this.productCache.size > 0 && useCache === true) {
      const cachedData = this.productCache.get(cacheKey);
      if (cachedData) {
        return of(cachedData); // Return the cached data directly
      }
    }

    let params = new HttpParams();

    if (this.shopParams.Brandsid !== 0) {
      params = params.append('brandId', this.shopParams.Brandsid.toString());
    }

    if (this.shopParams.CategoryId !== 0) {
      params = params.append('categoryId', this.shopParams.CategoryId.toString());
    }

    if (this.shopParams.search) {
      params = params.append('search', this.shopParams.search);
    }

    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageIndex.toString());
    params = params.append('pageSize', this.shopParams.pageSize.toString());

    return this.http.get<Pagination>(`${this.baseUrl}`, { observe: 'response', params })
      .pipe(
        map(response => {
          const paginationData = response.body ?? new Pagination();
          this.productCache.set(cacheKey, paginationData);
          return paginationData;
        })
      );
  }


  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }

  getShopParams() {
    return this.shopParams;
  }
}
