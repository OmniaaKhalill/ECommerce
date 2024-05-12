import { Component } from '@angular/core';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { ProductContentComponent } from '../product-content/product-content.component';
import { ToolboxComponent } from '../../ShopPage/toolbox/toolbox.component';
import { BrandSectionComponent } from '../../ShopPage/brand-section/brand-section.component';

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

}
