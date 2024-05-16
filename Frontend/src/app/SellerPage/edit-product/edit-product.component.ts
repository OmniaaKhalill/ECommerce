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
import { ActivatedRoute } from '@angular/router';

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
  Editedproduct:Product=new Product(0,"","",0,0,[],0,"","",1,[]);
   id:number= Number(this.route.snapshot.paramMap.get('id'));
constructor(
  private route: ActivatedRoute,
  private productService: ProductService,
  public router:Router ,
  private imageServece:ImegesService,
  public CategoryService:CategoryService
) {}
  ngOnInit(): void 
  {
   this.getAllCategories();
   this.getProductByID();
   
  }
  ngOnDestroy(): void
  {
   this.sub?.unsubscribe;
   
  }
  getAllCategories()
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
  getProductByID(){
    const productId =this.id;

    this.productService.GetById(productId).subscribe(
      (product)=>{
        this.Editedproduct=product;
        console.log(product);
      }
    )
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
    this.productService.update(this.Editedproduct, this.id).subscribe(
      () => {
        console.log("The product updated successfully");
      },
      (error) => {
        console.log(error);
      }
    );
  }

}

