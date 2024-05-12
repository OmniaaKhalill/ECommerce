import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {


  constructor(public http:HttpClient)
   {

   }

   public GetAll()
   {
    return this.http.get<Category[]>("https://localhost:7191/api/Category");
   }
}
