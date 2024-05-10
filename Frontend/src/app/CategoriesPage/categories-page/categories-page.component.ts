import { Component } from '@angular/core';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';

@Component({
  selector: 'app-categories-page',
  standalone: true,
  imports: [
    PageHeaderComponent,
    BreadcrumbComponent
  ],
  templateUrl: './categories-page.component.html',
  styleUrl: './categories-page.component.css'
})
export class CategoriesPageComponent {

}
