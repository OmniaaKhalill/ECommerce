import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { order } from '../models/order';
import { shippingAddress } from '../models/shipping-address';

@Injectable({
  providedIn: 'root'
})
export class OrderService {


 
  private baseUrl="https://localhost:7191/api/"

  createOrder(Order:order): Promise<boolean> {
    let str: string = `orders`;
  
    return new Promise<boolean>((resolve) => {
      this.http.post(this.baseUrl + str, Order, { responseType: 'text' }).subscribe(
        (response) => {
          
       return response
          resolve(true); // Resolve the promise indicating successful login
        },
        (error) => {
          console.error("Error occurred during  creating order:", error);
          resolve(false); // Resolve the promise indicating failed login
        }
      );
    });
  }

    constructor(public http:HttpClient) { }
}
