import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/order';
import { ShippingAddress } from '../models/shipping-address';

@Injectable({
  providedIn: 'root'
})
export class OrderService {



  
   shippingAddress = new ShippingAddress("John", "Doe", "123 Main St", "Springfield", "USA");
   order = new Order("john.doe@example.com", "cart123", this.shippingAddress);


 
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

    constructor(public http:HttpClient) { }
}
