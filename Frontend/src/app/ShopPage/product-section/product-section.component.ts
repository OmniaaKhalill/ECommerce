import { Component } from '@angular/core';
import { ProductService } from '../../Services/product.service';

@Component({
  selector: 'app-product-section',
  standalone: true,
  imports: [],
  templateUrl: './product-section.component.html',
  styleUrl: './product-section.component.css'
})
export class ProductSectionComponent {

  constructor(public productService:ProductService) {

  }
  Load() {
    this.productService.GetProducts();
  }
}
