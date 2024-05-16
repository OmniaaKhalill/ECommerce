import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NavbarComponent } from '../../HomePage/navbar/navbar.component';
import { FooterComponent } from '../../core/footer/footer.component';
import { HeaderComponent } from '../../HomePage/header/header.component';
import {  RouterLink, RouterOutlet } from '@angular/router';
import { SimilarProductsComponent } from '../similar-products/similar-products.component';

@Component({
  selector: 'app-single-product',
  standalone: true,
  imports: [CommonModule,NavbarComponent,FooterComponent,HeaderComponent,RouterLink,RouterOutlet,SimilarProductsComponent],
  templateUrl: './single-product.component.html',
  styleUrl: './single-product.component.css'
})
export class SingleProductComponent {
  smallerImages: string[] = [
    "../../../assets/img/Home/product1.jpeg",
    "../../../assets/img/Home/product2.jpeg",
    "../../../assets/img/Home/product3.jpeg",
    "../../../assets/img/Home/product4.jpeg"
  ];
  bigImage: string = this.smallerImages[0]; 

  changeBigImage(image: string) {
    this.bigImage = image;
  }
  preventReload(event: MouseEvent) {
   
    event.preventDefault();
    
  }

  increment() {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue + 1;
    if (newValue <= 10) {
      qtyInput.value = newValue.toString();
    }
  }

  decrement() {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue - 1;
    if (newValue >= 1) {
      qtyInput.value = newValue.toString();
    }
  }

  activeTab: string = 'description';

  isActive(tab: string): boolean {
    return this.activeTab === tab;
  }

  setActive(tab: string): void {
    this.activeTab = tab;
  }
}
