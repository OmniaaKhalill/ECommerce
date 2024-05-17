import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Page } from '../models/page';

@Injectable({
  providedIn: 'root'
})
export class PageService {

 
  baseurl="https://localhost:7191/api/Page";
  constructor(public http:HttpClient) { }
 
  AddPage(newPage: Page, sellerId: number): Observable<Page> {
    
    return this.http.post<Page>(`${this.baseurl}/${sellerId}`, newPage);
  }

  GetPage(sellerId:number):Observable<Page>{
    return this.http.get<Page>(`${this.baseurl}/seller/${sellerId}`);
  }
}
