import { Component } from '@angular/core';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-category-page',
  standalone: true,
  imports: [
    PageHeaderComponent,
    BreadcrumbComponent,
    RouterLink
  ],
  templateUrl: './category-page.component.html',
  styleUrl: './category-page.component.css'
})
export class CategoryPageComponent {
  PageName:string="Categories";
}
