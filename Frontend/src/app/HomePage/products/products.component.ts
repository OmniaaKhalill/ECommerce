import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import {  RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule,RouterLink],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {

  products: Product[] = [];
  productGroups: Product[][] = [];
  isAuth: boolean | undefined;

  constructor(
    public accountService: AccountService,
    public productService: ProductService,
   
  ) {}

  ngOnInit(): void {
    this.productService.GetAllProducts().subscribe(
      data => {
        this.products = data.slice(0, 6); 
        this.groupProducts();
      },
      err => {
        console.log(err);
      }
    );
  }

  groupProducts(): void {
    this.productGroups = [];
    for (let i = 0; i < this.products.length; i += 4) {
      this.productGroups.push(this.products.slice(i, i + 4));
    }
  }
}





