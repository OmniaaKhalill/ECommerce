import { Component } from '@angular/core';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';

@Component({
  selector: 'app-category-page',
  standalone: true,
  imports: [
    PageHeaderComponent,
    BreadcrumbComponent
  ],
  templateUrl: './category-page.component.html',
  styleUrl: './category-page.component.css'
})
export class CategoryPageComponent {

}
