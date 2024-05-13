import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as jwtDecode from 'jwt-decode'
@Injectable({
  providedIn: 'root'
})
export class AccountService {

  isAuthenticated =false;
  private baseUrl="https://localhost:7191/api/Account"

  login(email:string , password:string){
 let str:String = `/Login`;
 this.http.post(this.baseUrl+str,{email,password},{responseType:'text'}  ).subscribe(response=>{
  this.isAuthenticated =true;
  localStorage.setItem("token",response) 
 })

  }


  register(displayName:string,email:string,password:string){
    let str:String = `/Register`;
    this.http.post(this.baseUrl + str,{ displayName, email, password },{responseType:'text'}).subscribe(response => {

      this.isAuthenticated =true;
    localStorage.setItem("token", response);
  })
   
}
  

  logout(){
    localStorage.removeItem("token")
    this.isAuthenticated =false;
  }




  constructor(public http:HttpClient) { }
}
