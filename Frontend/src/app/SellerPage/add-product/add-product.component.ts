import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators, FormArray } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ImegesService } from '../../services/imeges.service';
import { ColorPickerModule } from 'ngx-color-picker';
import { Category } from '../../models/category';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { CategoryService } from '../../services/category.service';
import { BrandService } from '../../services/brand.service'; 
import { Brands } from '../../models/brands';
import { AccountService } from '../../services/account.service';
import { ProductToAdd } from '../../models/product-to-add';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [FormsModule, CommonModule, PageHeaderComponent, BreadcrumbComponent, ReactiveFormsModule, ReactiveFormsModule, ColorPickerModule],
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'] // corrected styleUrl to styleUrls
})
export class AddProductComponent implements OnDestroy, OnInit {
  pagename: string = "Add products";
  numOfColors: number = 0;
  colorNameInputs: string[] = [];

  imageUrl: string = "";
  sub: Subscription | null = null;
  hexval: string[] = [];
  categories: Category[] = [];
  brands: Brands[] = [];
  categoryName: string = "blach";
  brandName: string = "flomar";
  newproduct: ProductToAdd = new ProductToAdd("",0,0,[],0,"","",0);
  colorInputs: { name: string, hex: string }[] = [];


  constructor(
    private productService: ProductService,
    public router: Router,
    private imageService: ImegesService,
    public categoryService: CategoryService,
    public brandService: BrandService,
    public accountservice: AccountService
  ) {}

  ngOnInit(): void {
    this.getAllCategories();
    this.getAllBrands();

  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  getAllCategories() {
    this.categoryService.GetAll().subscribe(
      (data: Category[]) => {
        this.categories = data;
      },
      error => console.error(error)
    );
  }

  getAllBrands() {
    this.brandService.GetBrands().subscribe(
      (data: Brands[]) => {
        this.brands = data;
        console.log(data)
      },
      error => console.error(error)
    );
  }

  generateInputs(Name: string) {
   
      this.colorNameInputs = [];
      console.log("the number of colors "+this.numOfColors)
      for (let i = 0; i < this.numOfColors; i++) {
        this.colorInputs.push({"hex":"","name":""});
       
      }
      console.log(this.numOfColors);
      console.log(this.hexval);
 
  }

  removeInput(index: number) {
 
      this.colorNameInputs.splice(index, 1);
      this.hexval.splice(index, 1);
   
  }

  Add() {
    this.newproduct.colors = [];

    const selectedCategory = this.categories.find(category => category.name === this.categoryName);
    if (selectedCategory) {
      this.newproduct.categoryId = selectedCategory.id;
    }

    const selectedBrand = this.brands.find(brand => brand.name === this.brandName);
    if (selectedBrand) {
      this.newproduct.brandsid = selectedBrand.id;
    }
    this.newproduct.colors = this.colorInputs.map(color => ({ hex_value: color.hex, colour_name: color.name }));
    console.log(JSON.stringify(this.newproduct))
    const usrId = this.accountservice.getClaims().UserId;
    this.sub = this.productService.Add(this.newproduct, usrId).subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigateByUrl("/Product");
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  UploadImage(e: Event) {
    const input = e.target as HTMLInputElement;
    const file = input.files?.[0];
    if (file) {
      this.imageService.uploadImage(file).subscribe(
        (data) => {
          this.newproduct.image_link = data.url;
        },
        error => console.error(error)
      );
    }
  }
}
