import { Component } from '@angular/core';
import { PageHeaderComponent } from '../page-header/page-header.component';
import { BreadcrumbComponent } from '../breadcrumb/breadcrumb.component';
import { ToolboxComponent } from '../toolbox/toolbox.component';
import { ProductSectionComponent } from '../product-section/product-section.component';
import { CategorySectionComponent } from '../category-section/category-section.component';
import { BrandSectionComponent } from '../brand-section/brand-section.component';


@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [
    PageHeaderComponent,
    BreadcrumbComponent,
    ToolboxComponent,
    ProductSectionComponent,
    CategorySectionComponent,
    BrandSectionComponent,
  ],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent {

}
