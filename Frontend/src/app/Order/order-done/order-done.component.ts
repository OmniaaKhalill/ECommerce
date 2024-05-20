import { Component } from '@angular/core';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order-done',
  standalone: true,
  imports: [],
  templateUrl: './order-done.component.html',
  styleUrl: './order-done.component.css'
})
export class OrderDoneComponent {


  constructor(public orderService:OrderService){
   
  }
  goToPayment(){

     console.log("go to payment")
  }

}
