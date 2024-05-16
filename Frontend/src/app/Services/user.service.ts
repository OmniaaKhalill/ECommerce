import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
baseurl="https://localhost:7191/api/User";
  constructor(public http:HttpClient) { }


  GetById(Id: string): Observable<User> {
   
    const url = `${this.baseurl}/${Id}`;
    return this.http.get<User>(url);
  }
  update(user:User){
    return this.http.patch<User>(`${this.baseurl}/${user.id}`, user);
  }
}



