import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-section',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-section.component.html',
  styleUrl: './product-section.component.css'
})
export class ProductSectionComponent implements OnInit {

  products: Product[] = [];
  constructor(public productService: ProductService) {}

    ngOnInit() {
      this.productService.GetProducts().subscribe(data => {
        console.log(data);
        this.products = data;
      });
    }
}
