import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart-total',
  standalone: true,
  imports: [],
  templateUrl: './cart-total.component.html',
  styleUrl: './cart-total.component.css'
})
export class CartTotalComponent {
  [x: string]: any;

  constructor( public router :Router){

  }

  goToOrder(){


    this.router.navigateByUrl("/order")


  }
}
