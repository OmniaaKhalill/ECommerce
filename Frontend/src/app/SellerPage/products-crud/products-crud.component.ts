import { Component, output,EventEmitter } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { PaginationComponent } from '../pagination/pagination.component';
import { RouterLink } from '@angular/router';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';

@Component({
  selector: 'app-products-crud',
  standalone: true,
  imports: [PageHeaderComponent,PaginationComponent,RouterLink,BreadcrumbComponent],
  templateUrl: './products-crud.component.html',
  styleUrl: './products-crud.component.css'
})
export class ProductsCrudComponent {
Pagename:string="Products";

}
