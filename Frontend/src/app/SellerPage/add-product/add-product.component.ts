import { CommonModule } from '@angular/common';
import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule,Validators,FormArray } from '@angular/forms';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../models/product';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import{ImegesService} from '../../Services/imeges.service'
import { ColorPickerModule } from 'ngx-color-picker';


@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [FormsModule,CommonModule,PageHeaderComponent,BreadcrumbComponent,ReactiveFormsModule,ReactiveFormsModule,ColorPickerModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent implements OnDestroy
 {
  pagename:string="Add products"
  numOfColors: number=0;
  colorNameInputs: string[] = [];
  numOfTags:number=0;
  TagsInput:string[]=[];
  imageUrl: string="";
  sub:Subscription|null=null;
  hexval:string[]=[];
  

  newproduct:Product=new Product("","","Select Category",0,[{name:"jjj",hexVal:"kkk"}],[],0,"","");
constructor(private productService: ProductService,public router:Router,private imageServece:ImegesService) 
{

}
  ngOnDestroy(): void {

this.sub?.unsubscribe;
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
  
  Add(){
    this.newproduct.Colors=[];
    this.newproduct.Tags=[];
    for (let i = 0; i < this.numOfColors; i++) {
      // Create a new color object
      const color = {
          name: this.colorNameInputs[i], // Assign the name
          hexVal: this.hexval[i] // Assign the hex value
      };
      // Push the color object into the Colors array
      this.newproduct.Colors.push(color);
  //  this.sub= this.productService.Add(this.newproduct).subscribe(
  //     data=>{
  //       console.log(data);
  //       this.router.navigateByUrl("/Products");
  //     }
  //   );   
  console.log(this.newproduct.Colors)

  console.log(this.newproduct);
  console.log(this.hexval)
  }
  }
  UploadImage(e:Event){
    console.log("hello fron func")
    const input=e.target as HTMLInputElement;
    const file=input.files?.[0];
    if(file){
      this.imageServece.uploadImage(file).subscribe(
        (data) => {
          console.log(data);
          this.newproduct.ImageLink = data.url; // Adjusted to lower case 'url'
          console.log(JSON.stringify(data.url));
        }
      );

    }
  }
}

