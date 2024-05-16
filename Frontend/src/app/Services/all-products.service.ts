import { IPagination, Pagination } from './../models/pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { ShopParams } from '../models/shop-params';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AllProductsService {
  private baseurl = "https://localhost:7191/api/Shop";
  products: Product[] = [];
  pagination = new Pagination();
  shopParams = new ShopParams();
  productCache = new Map();

  constructor(public http: HttpClient) { }

  // GetProducts(useCache: boolean) {
  //   debugger;
  //   if (useCache === false) {
  //     this.productCache = new Map();
  //   }
  //   if (this.productCache.size > 0 && useCache === true) {
  //     if (this.productCache.has(Object.values(this.shopParams).join('-'))) {
  //       this.pagination.data = this.productCache.get(Object.values(this.shopParams).join('-'));
  //       return of(this.pagination);
  //     }
  //   }
  //   let params = new HttpParams();

  //   if (this.shopParams.Brandsid !== 0) {
  //     params = params.append('brandsid', this.shopParams.Brandsid.toString())
  //   }

  //   if (this.shopParams.CategoryId !== 0) {
  //     params = params.append('categoryId', this.shopParams.CategoryId.toString())
  //   }

  //   if (this.shopParams.search) {
  //     params = params.append('search', this.shopParams.search)
  //   }

  //   params = params.append('sort', this.shopParams.sort);
  //   params = params.append('pageIndex', this.shopParams.pageIndex.toString());
  //   params = params.append('pageSize', this.shopParams.pageSize.toString());

  //   return this.http.get<IPagination>(this.baseurl + 'shop', { observe: 'response', params })
  //   .pipe(
  //     map(response => {
  //       this.productCache.set(Object.values(this.shopParams).join('-'), response.body.data);
  //       this.pagination = response.body;
  //       return this.pagination;
  //     })
  //   )
  // }

  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }

  getShopParams() {
    return this.shopParams;
  }

  // getProduct(id: number) {
  //   let product: IProduct;
  //   this.productCache.forEach((products: IProduct[]) => {
  //     console.log(product);
  //     product = products.find(p => p.id === id);
  //   })

  //   if (product) {
  //     return of(product);
  //   }

  //   return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  // }
}
