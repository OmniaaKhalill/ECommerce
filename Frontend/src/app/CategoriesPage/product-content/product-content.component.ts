import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Product } from '../../models/product';

import { CommonModule } from '@angular/common';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-product-content',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-content.component.html',
  styleUrl: './product-content.component.css'
})
export class ProductContentComponent {
  product: Product[] = [];
  constructor(public activatedRoute: ActivatedRoute, public categoriesService: CategoryService) {}

  ngOnInit():void{
    this.activatedRoute.params.subscribe(p =>{
      this.categoriesService.GetProductsByCategory(p['categoryId']).subscribe(d=>this.product = d)
    })
    }
}
