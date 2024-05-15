import { HttpClient } from '@angular/common/http';
import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import * as jwtDecode from 'jwt-decode'
@Injectable({
  providedIn: 'root'
})
export class AccountService {

  isAuthenticated =false; 

  claims:{Name:string, Email:string, IsSeller:string , UserId:string }|undefined
 
  private baseUrl="https://localhost:7191/api/Account"

  login(email: string, password: string): Promise<boolean> {
    let str: string = `/Login`;
  
    return new Promise<boolean>((resolve) => {
      this.http.post(this.baseUrl + str, { email, password }, { responseType: 'text' }).subscribe(
        (response) => {
          this.isAuthenticated = true;
          localStorage.setItem("token", response);
          this.claims = jwtDecode.jwtDecode(response);
          console.log(this.claims);
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
          this.isAuthenticated = true;
          localStorage.setItem("token", response);
          this.claims = jwtDecode.jwtDecode(response);
        
          resolve(true); // Resolve the promise indicating success
        },
        (error) => {
          console.error("Error occurred during registration:", error);
          resolve(false); // Resolve the promise indicating failure
        }
      );
    });
  }
  
  
  



  logout(){
    localStorage.removeItem("token")
    this.isAuthenticated =false;
  }




  constructor(public http:HttpClient) { }
}
