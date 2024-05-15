import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cart-products',
  standalone: true,
  imports: [],
  templateUrl: './cart-products.component.html',
  styleUrl: './cart-products.component.css'
})
export class CartProductsComponent {


  ProductPrice: number = 84;
  Total: number = this.ProductPrice;
  
  increment() {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue + 1;
  
    if (newValue <= 10) {
      qtyInput.value = newValue.toString();
      this.Total = this.ProductPrice * newValue; // Update total
    }
  }
  
  decrement() {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue - 1;
  
    if (newValue >= 1) {
      qtyInput.value = newValue.toString();
      this.Total = this.ProductPrice * newValue; // Update total
    }
  }
  
}
