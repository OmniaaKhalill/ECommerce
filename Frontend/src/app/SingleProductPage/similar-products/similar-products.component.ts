import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-similar-products',
  standalone: true,
  imports: [CommonModule,RouterLink],
  templateUrl: './similar-products.component.html',
  styleUrl: './similar-products.component.css'
})
export class SimilarProductsComponent {

  products: Product[] = []; 
  product:Product = new Product(0,"",0,0,[],0,"","",0,[],"",0,"");

  constructor(public productService: ProductService, public activatedRoute: ActivatedRoute) {}

  ngOnInit() {
   
    this.activatedRoute.params.subscribe(params => {
      const productId = params['id'];
     
      this.productService.GetById(productId).subscribe(product => {
        this.product = product;
       
        this.loadSimilarProducts(product.categoryId);
      });
    });
  }


  loadSimilarProducts(categoryId: number) {
    this.productService.GetProductsByCategoryId(categoryId).subscribe(
      data => {
        this.products = data; 
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
  }



}
