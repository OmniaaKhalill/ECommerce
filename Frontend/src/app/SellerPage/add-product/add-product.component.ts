import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule,Validators,FormArray } from '@angular/forms';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../models/product';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import{ImegesService} from '../../Services/imeges.service'
import { ColorPickerModule } from 'ngx-color-picker';
import { CategoryService } from '../../Services/category.service';
import { Category } from '../../models/category';


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
  categoryName:string="blach";
  

  newproduct:Product=new Product(0,"","",0,0,[],0,"","",1,[]);
constructor(
  private productService: ProductService,
  public router:Router ,
  private imageServece:ImegesService,
  public CategoryService:CategoryService
) {}
  ngOnInit(): void 
  {
   this.getAllProducts();
  }
  ngOnDestroy(): void
  {
   this.sub?.unsubscribe;
   
  }
  getAllProducts()
  {
    this.CategoryService.GetAll().subscribe(
      (data: Category[]) =>
      {
        console.log(data);
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
    else{

      this.TagsInput=[];
      for (let i = 0; i < this.numOfTags; i++) {
        this.TagsInput.push('');
        console.log(this.numOfColors);

      }
    }}

  removeInput(index: number,s:string) {
    if(s==="color"){
      this.colorNameInputs.splice(index, 1);

    }
    else if(s==="Tag"){
      this.TagsInput.splice(index, 1);


    }
  }
  
  Add()
  {
    this.newproduct.colors=[];
  
    for(let i = 0; i < this.categories.length; i++) {
      if(this.categories[i].name === this.categoryName) {
          this.newproduct.categoryId = this.categories[i].id;
          console.log(this.newproduct.categoryId);
          console.log(this.categories[i].id);
          break; 
      }
  }
    for (let i = 0; i < this.numOfColors; i++) 
      {
      // Create a new color object
      const color = {
        hex_value: this.colorNameInputs[i], // Assign the name
        colour_name: this.hexval[i] // Assign the hex value
      };
      // Push the color object into the Colors array
      this.newproduct.colors.push(color);
      const sellerId=1;
   this.sub= this.productService.Add(this.newproduct,sellerId).subscribe(
      data=>{
        console.log(data);
        this.router.navigateByUrl("/Product");
      }
    );   }
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

