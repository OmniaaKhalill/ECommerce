import { Component, OnInit } from '@angular/core';
import { PageHeaderComponent } from '../page-header/page-header.component';
import { BreadcrumbComponent } from '../breadcrumb/breadcrumb.component';
import { ToolboxComponent } from '../toolbox/toolbox.component';
import { ProductSectionComponent } from '../product-section/product-section.component';
import { CategorySectionComponent } from '../category-section/category-section.component';
import { BrandSectionComponent } from '../brand-section/brand-section.component';
import { AccountService } from '../../services/account.service';
import { Subscription } from 'rxjs';
import { Product } from '../../models/product';
import { SearchService } from '../../services/search.service';
// import { ShopService } from '../../services/shop.service';


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
export class ShopComponent{
  // products: Product[] = [];
  // searchTextSubscription!: Subscription;

  // constructor(private shopService: ShopService, private searchService: SearchService) {}

  // ngOnInit() {
  //   this.loadProducts();

  //   this.searchTextSubscription = this.searchService.searchText$.subscribe((searchText) => {
  //     this.products = this.products.filter((product) =>
  //       product.name.toLowerCase().includes(searchText.toLowerCase())
  //     );
  //   });
  // }

  // ngOnDestroy() {
  //   if (this.searchTextSubscription) {
  //     this.searchTextSubscription.unsubscribe();
  //   }
  // }

  // loadProducts() {
  //   this.shopService.GetAllProducts().subscribe(data => {
  //     this.products = data;
  //     this.sortProducts();
  //   });
  // }

  // onSortChanged(sort: string) {
  //   const params = this.shopService.getShopParams();
  //   params.sort = sort;
  //   this.shopService.setShopParams(params);
  //   this.loadProducts();
  // }

  // sortProducts() {
  //   const sortOption = this.shopService.getShopParams().sort;
  //   switch (sortOption) {
  //     case 'priceAsc':
  //       this.products.sort((a, b) => a.price - b.price);
  //       break;
  //     case 'priceDesc':
  //       this.products.sort((a, b) => b.price - a.price);
  //       break;
  //     case 'name':
  //     default:
  //       this.products.sort((a, b) => a.name.localeCompare(b.name));
  //       break;
  //   }
  // }
}
