import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule,Validators,FormArray } from '@angular/forms';

import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import{ImegesService} from '../../services/imeges.service'
import { ColorPickerModule } from 'ngx-color-picker';

import { Category } from '../../models/category';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { CategoryService } from '../../services/category.service';
import { BrandService } from '../../services/brand.service';
import { Brands } from '../../models/brands';
import { AccountService } from '../../services/account.service';




@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [FormsModule,CommonModule,PageHeaderComponent,BreadcrumbComponent,ReactiveFormsModule,ReactiveFormsModule,ColorPickerModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent implements OnDestroy,OnInit
 {

  pagename:string="Add products"
  numOfColors: number=0;
  colorNameInputs: string[] = [];
  numOfTags:number=0;
  TagsInput:string[]=[];
  imageUrl: string="";
  sub:Subscription|null=null;
  hexval:string[]=[];
  categories:Category[]=[];
  brands:Brands[]=[];
  categoryName:string="blach";
  brandName:string="flomar";
  newproduct:any={};
constructor(
  private productService: ProductService,
  public router:Router ,
  private imageServece:ImegesService,
  public categoryService:CategoryService,
  public brandService:BrandService,
  public accountservice:AccountService
) {}
  ngOnInit(): void 
  {
    this.getAllCategories();
    this.getAllBrands()
  
  }
  onloaed(){
   
    
  }
  ngOnDestroy(): void
  {
   this.sub?.unsubscribe;
   
  }
  getAllCategories()
  {
    this.categoryService.GetAll().subscribe(
      (data: Category[]) =>
      {
        console.log("helo from categories"+data);
        this.categories = data;
        console.log("lvkvf"+this.categories)
        this.categories.forEach(category => {
          // Log or perform operations on each category object
          console.log(category); // Example: Log each category object to the console
      });
      console.log(this.categories[0])
      }
    );
  }
  getAllBrands()
  {
    this.brandService.GetBrands().subscribe(
      (data: Brands[]) =>
      {
        console.log("helllllllllllo from brands"+data);
        this.brands = data;
        console.log("lvkvf"+this.brands)
        this.brands.forEach(brand => {
          // Log or perform operations on each category object
          console.log(brand); // Example: Log each category object to the console
      });
      console.log(this.brands[0])
      }
    );
  }
  
  generateInputs(Name:string) 
  {
    
    if(Name==="color")
      {
      this.colorNameInputs = [];
      for (let i = 0; i < this.numOfColors; i++) {
        this.colorNameInputs.push('');
        this.hexval.push('');
      }
      console.log(this.numOfColors);
      console.log(this.hexval)
      

    }
    
    }

  removeInput(index: number,s:string) {
    if(s==="color"){
      this.colorNameInputs.splice(index, 1);

    }
    else if(s==="Tag"){
      this.TagsInput.splice(index, 1);


    }
  }
  
  Add() {
    this.newproduct.colors = [];
  
    for (let i = 0; i < this.categories.length; i++) {
      if (this.categories[i].name === this.categoryName) {
        this.newproduct.categoryId = this.categories[i].id;
        console.log(this.newproduct.categoryId);
        console.log(this.categories[i].id);
        break;
      }
    }
    for (let i = 0; i < this.brands.length; i++) {
      if (this.brands[i].name === this.brandName) {
        this.newproduct.brandid = this.brands[i].id;
        console.log(this.newproduct.brandid);
        console.log(this.brands[i].id);
        break;
      }
    }
  
    for (let i = 0; i < this.numOfColors; i++) {
      const color = {
        hex_value: this.hexval[i],
        colour_name: this.colorNameInputs[i]
      };
      this.newproduct.colors.push(color);
    }
  
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
  
  UploadImage(e:Event){
    console.log("hello fron func")
    console.log("categories"+this.categories[0]);
    const input=e.target as HTMLInputElement;
    const file=input.files?.[0];
    if(file){
      this.imageServece.uploadImage(file).subscribe(
        (data) => {
          console.log(data);
          this.newproduct.image_link = data.url; // Adjusted to lower case 'url'
          console.log(JSON.stringify(data.url));
          console.log("this is the image url" +this.newproduct.image_link);
        }
      );

    }
  }

}