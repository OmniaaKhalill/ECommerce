import { Component, OnInit } from '@angular/core';

import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';
import { SearchService } from '../../services/search.service';

@Component({
  selector: 'app-product-section',
  standalone: true,
  imports: [CommonModule, FormsModule,RouterLink],
  templateUrl: './product-section.component.html',
  styleUrl: './product-section.component.css'
})
export class ProductSectionComponent implements OnInit {
  products: Product[] = [];
  filteredProducts: Product[] = [];
  searchTextSubscription!: Subscription;

  constructor(private productService: ProductService, private searchService: SearchService) {}

  ngOnInit() {
    this.productService.GetAllProducts().subscribe((data) => {
      this.products = data;
      this.filteredProducts = data;
    });

    this.searchTextSubscription = this.searchService.searchText$.subscribe((searchText) => {
      this.filteredProducts = this.products.filter((product) =>
        product.name.toLowerCase().includes(searchText.toLowerCase())
      );
    });
  }

  ngOnDestroy() {
    if (this.searchTextSubscription) {
      this.searchTextSubscription.unsubscribe();
    }
  }
}
