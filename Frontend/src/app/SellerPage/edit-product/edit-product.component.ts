import { CommonModule, JsonPipe } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule,Validators,FormArray } from '@angular/forms';

import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import{ImegesService} from '../../services/imeges.service'
import { ColorPickerModule } from 'ngx-color-picker';

import { Category } from '../../models/category';
import { ActivatedRoute } from '@angular/router';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { CategoryService } from '../../services/category.service';
import { BrandService } from '../../services/brand.service';
import { Brands } from '../../models/brands';
import { ProductToAdd } from '../../models/product-to-add';
import { ProductToEdite } from '../../models/product-to-edite';

@Component({
  selector: 'app-edit-product',
  standalone: true,
  imports: [FormsModule,CommonModule,PageHeaderComponent,BreadcrumbComponent,ReactiveFormsModule,ReactiveFormsModule,ColorPickerModule],
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent {

  pagename:string="Edite products"
  numOfColors: number=0;
  colorNameInputs: string[] = [];
  numOfTags:number=0;
  TagsInput:string[]=[];
  imageUrl: string="";
  sub:Subscription|null=null;
  hexval:string[]=[];
  categories:Category[]=[];
  categoryName:string="blach";
  Editedproduct:ProductToEdite=new ProductToEdite(0,"",0,0,[],0,"","",0,0);
  brands: Brands[] = [];
  colorInputs: { name: string, hex: string }[] = [];


   id:number= Number(this.route.snapshot.paramMap.get('id'));
constructor(
  private route: ActivatedRoute,
  private productService: ProductService,
  public router:Router ,
  private imageServece:ImegesService,
  public categoryService:CategoryService,
  public brandsService:BrandService
) {}
  ngOnInit(): void 
  {
   this.getAllCategories();
   this.getProductByID();  
   this.getAllBrands();
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

  
  getAllBrands() {
    this.brandsService.GetBrands().subscribe(
      (data: Brands[]) => {
        this.brands = data;
        console.log(data)
      },
      error => console.error(error)
    );
  }
  getProductByID(){
    const productId =this.id;

    this.productService.GetById(productId).subscribe(
      (product)=>{
        console.log(JSON.stringify(product));
        this.Editedproduct.id=this.id;
this.Editedproduct.brandsid=product.brandsid;
this.Editedproduct.categoryId=product.categoryId;
this.Editedproduct.colors=product.colors;
this.Editedproduct.description=product.description;
this.Editedproduct.image_link=product.image_link;
this.Editedproduct.name=product.name;
this.Editedproduct.numOfProductInStock=product.numOfProductInStock;
this.Editedproduct.price=product.price;
this.Editedproduct.sellerId=product.sellerId;
// this.Editedproduct.sellerId=product.sellerId;
console.log("the object editeproduct"+JSON.stringify(this.Editedproduct));
        console.log(product);
      }
    )
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

  
  UploadImage(e:Event){
    console.log("hello fron func")
    console.log("categories"+this.categories[0]);
    const input=e.target as HTMLInputElement;
    const file=input.files?.[0];
    if(file){
      this.imageServece.uploadImage(file).subscribe(
        (data) => {
          console.log(data);
          this.Editedproduct.image_link = data.url; // Adjusted to lower case 'url'
          console.log(JSON.stringify(data.url));
          console.log("this is the image url" +this.Editedproduct.image_link);
        }
      );

    }
  }



  update() {
    console.log("from updta func"+JSON.stringify(this.Editedproduct));
    this.sub = this.productService.update(this.Editedproduct, this.id).subscribe({
      next: (value: ProductToAdd) => { // Adjust the type to ProductToAdd
        console.log("The product updated successfully");
      },
      error: (error: any) => {
        console.log(error);
      }
    });
  }
  

}

