import { Component } from '@angular/core';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { ProductContentComponent } from '../product-content/product-content.component';
import { ToolboxComponent } from '../../ShopPage/toolbox/toolbox.component';
import { BrandSectionComponent } from '../../ShopPage/brand-section/brand-section.component';
import { Product } from '../../models/product';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-products-page',
  standalone: true,
  imports: [
    PageHeaderComponent,
    BreadcrumbComponent,
    ToolboxComponent,
    ProductContentComponent,
    BrandSectionComponent
  ],
  templateUrl: './products-page.component.html',
  styleUrl: './products-page.component.css'
})
export class ProductsPageComponent {
  product: Product[] = [];
  constructor(public activatedRoute: ActivatedRoute, public categoriesService: CategoryService) {}

  ngOnInit():void{
    this.activatedRoute.params.subscribe(p =>{
      this.categoriesService.GetProductsByCategory(p['id']).subscribe(d=>this.product = d)
    })
    }
}
