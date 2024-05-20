import { Component, OnInit } from '@angular/core';
import { PageHeaderComponent } from '../page-header/page-header.component';
import { BreadcrumbComponent } from '../breadcrumb/breadcrumb.component';
import { ToolboxComponent } from '../toolbox/toolbox.component';
import { ProductSectionComponent } from '../product-section/product-section.component';
import { CategorySectionComponent } from '../category-section/category-section.component';
import { BrandSectionComponent } from '../brand-section/brand-section.component';
import { AccountService } from '../../services/account.service';


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
export class ShopComponent implements OnInit {

  constructor(public accountService:AccountService){}

  ngOnInit(){
     console.log(this.accountService.getClaims().UserId);
  }
}
