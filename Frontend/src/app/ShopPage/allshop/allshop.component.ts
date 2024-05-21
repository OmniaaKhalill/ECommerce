import { Component, ElementRef, ViewChild } from '@angular/core';
import { BreadcrumbComponent } from '../breadcrumb/breadcrumb.component';
import { PageHeaderComponent } from '../page-header/page-header.component';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { Category } from '../../models/category';
import { CategoryService } from '../../services/category.service';
import { Brands } from '../../models/brands';
import { BrandService } from '../../services/brand.service';
import { ShopService } from '../../services/shop.service';
import { ShopParams } from '../../models/shop-params';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-allshop',
  standalone: true,
  imports: [
    PageHeaderComponent,
    BreadcrumbComponent,
    CommonModule,
    FormsModule,
    RouterLink
  ],
  templateUrl: './allshop.component.html',
  styleUrl: './allshop.component.css'
})
export class AllshopComponent {
  @ViewChild('search', { static: false }) searchTerm!: ElementRef;

  sortOptions = [
    { name: 'Alphabetical', value: 'name', selected: false },
    { name: 'Price: Low to high', value: 'priceAsc', selected: false },
    { name: 'Price: High to low', value: 'priceDesc', selected: false },
  ];

  sortedProducts: any[] = [];

  searchTermValue: string = '';

  products: Product[] = [];
  categories: Category[] = [];
  brand: Brands[] = [];
  totalCount: number = 0;
  shopParams = new ShopParams();
  constructor(
    private productService: ProductService,
    public categoryService: CategoryService,
    public brandService: BrandService,
    public shopService:ShopService
  ) {}

  ngOnInit() {
    this.productService.GetAllProducts().subscribe((data) => {
      this.products = data;
    });
    this.categoryService.GetCategories().subscribe(data => {
      console.log(data);
      this.categories = data;
    });
    this.brandService.GetBrands().subscribe(data => {
      console.log(data);
      this.brand = data;
    });
    this.sortedProducts = [...this.products];
  }

  // getProducts(useCache = false) {
  //   this.shopService.getProducts(useCache).subscribe(response => {
  //     this.products = response.Data;
  //     this.totalCount = response.Count;
  //     console.log("Shop Params", this.shopParams);
  //   }, error => {
  //     console.log(error);
  //   })
  // }

  sortProducts(event: any) {
    switch (event) {
      case 'name':
        this.sortedProducts.sort((a, b) => a.name.localeCompare(b.name));
        break;
      case 'priceAsc':
        this.sortedProducts.sort((a, b) => a.price - b.price);
        break;
      case 'priceDesc':
        this.sortedProducts.sort((a, b) => b.price - a.price);
        break;
      default:
        break;
    }
  }

  // onSortSelected(event: any) {
  //   const sortValue = event?.target?.value;
  //   if (sortValue) {
  //     const params = this.shopService.getShopParams();
  //     if (!params) {
  //       console.error('ShopParams object is undefined.');
  //       return;
  //     }
  //     params.sort = sortValue;
  //     this.shopService.setShopParams(params);
  //     switch (sortValue) {
  //       case 'priceAsc':
  //         this.products.sort((a, b) => a.price - b.price);
  //         break;
  //       case 'priceDesc':
  //         this.products.sort((a, b) => b.price - a.price);
  //         break;
  //       case 'name':
  //         this.products.sort((a, b) => a.name.localeCompare(b.name));
  //         break;
  //       default:
  //         break;
  //     }
  //     console.log("Sorted Products:", this.products);
  //     this.getProducts();
  //     console.log("After returning Sorted Products:", this.products);
  //   }
  // }
  onSearch() {
    if (this.searchTermValue.trim() !== '') {
      this.productService.GetAllProducts().subscribe((data) => {
        this.products = data.filter(product =>
          product.name.toLowerCase().includes(this.searchTermValue.toLowerCase())
        );
      });
    } else {
      this.productService.GetAllProducts().subscribe((data) => {
        this.products = data;
      });
    }
  }
  onReset() {
    this.searchTermValue = '';
    this.productService.GetAllProducts().subscribe((data) => {
      this.products = data;
    });
  }
  onCategorySelected(categoryId: number) {
    if (categoryId) {
      this.categoryService.GetProductsByCategory(categoryId).subscribe((data) => {
        this.products = data;
      });
    } else {
      this.productService.GetAllProducts().subscribe((data) => {
        this.products = data;
      });
    }
  }
  onBrandSelected(brandsid: number) {
    if (brandsid) {
      this.brandService.GetProductsByBrand(brandsid).subscribe((data) => {
        console.log("Found:", data);
        this.products = data;
      });
    } else {
      this.productService.GetAllProducts().subscribe((data) => {
        console.log("Not Found:", data);
        this.products = data;
      });
    }
  }


  trackByIdentity(index: number, item: any) {
    return item.id;
  }

  trackByFn(index: number, item: Product): number {
    return item.id; // or item.id depending on your unique identifier
  }
}