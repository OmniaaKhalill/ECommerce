import { Component, OnInit } from '@angular/core';

import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-product-section',
  standalone: true,
  imports: [CommonModule, FormsModule,RouterLink],
  templateUrl: './product-section.component.html',
  styleUrl: './product-section.component.css'
})
export class ProductSectionComponent implements OnInit {

  products: Product[] = [];
  constructor(public productService: ProductService) {}
  isBrandsObject(brands: any): boolean {
    return typeof brands === 'object';
  }

    ngOnInit() {
      this.productService.GetAllProducts().subscribe(data => {
        console.log(data);
        this.products = data;
      });
    }
}
