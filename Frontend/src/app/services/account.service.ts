import { HttpClient } from '@angular/common/http';
import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import * as jwtDecode from 'jwt-decode'
import { BehaviorSubject } from 'rxjs';
import { session } from '../models/User/session';
@Injectable({
  providedIn: 'root'
})
export class AccountService {

  public claims=new session(false,"","","","")

 
  user!: { isAuthenticated: boolean; Name: string; Email: string; IsSeller: string; UserId: string; };
 
  private baseUrl="https://localhost:7191/api/Account"

  login(email: string, password: string): Promise<boolean> {
    let str: string = `/Login`;
  
    return new Promise<boolean>((resolve) => {
      this.http.post(this.baseUrl + str, { email, password }, { responseType: 'text' }).subscribe(
        (response) => {
          
       
          
          localStorage.setItem("token", response);
       
          resolve(true); // Resolve the promise indicating successful login
        },
        (error) => {
          console.error("Error occurred during login:", error);
          resolve(false); // Resolve the promise indicating failed login
        }
      );
    });
  }
  

  register(displayName: string, email: string, password: string): Promise<boolean> {
    let str: string = `/Register`;
  
    return new Promise<boolean>((resolve) => {
      this.http.post(this.baseUrl + str, { displayName, email, password }, { responseType: 'text' }).subscribe(
        (response) => {
   

          
          localStorage.setItem("token", response);
     
        
          resolve(true); // Resolve the promise indicating success
        },
        (error) => {
          console.error("Error occurred during registration:", error);
          resolve(false); // Resolve the promise indicating failure
        }
      );
    });
  }
  
  
  
  //  checkAuthenticationStatus :boolean() {
   
  //  return this.isAuthenticated$.next(this.isAuthenticated);
  // }



  getClaims(): session {
    let token = localStorage.getItem("token");
    

    if (typeof token === 'string' && token ) {
      this.claims.isAuthenticated=true
      this.user = jwtDecode.jwtDecode(token);
  
      this.claims.Email=this.user?.Email
      this.claims.Name=this.user.Name
      this.claims.UserId=this.user.UserId
      this.claims.IsSeller=this.user.IsSeller
    }
   
    
 console.log(this.claims);
    return this.claims;
    
  }
  
  logout(){
    localStorage.removeItem("token")
   this.claims.isAuthenticated=false
  }




  constructor(public http:HttpClient) { }
}
