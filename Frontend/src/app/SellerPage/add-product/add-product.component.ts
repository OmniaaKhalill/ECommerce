import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule,Validators,FormArray } from '@angular/forms';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BrandSectionComponent } from '../../ShopPage/brand-section/brand-section.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [FormsModule,CommonModule,PageHeaderComponent,BreadcrumbComponent,ReactiveFormsModule,ReactiveFormsModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent
 {
  pagename:string="Add products"
  numOfColors: number=0;
  colorInputs: string[] = [];
  numOfTags:number=0;
  TagsInput:string[]=[];
  imageUrl: string | ArrayBuffer | null = null;

  generateInputs(Name:string) 
  {
    
    if(Name==="color")
      {
      this.colorInputs = [];
      for (let i = 0; i < this.numOfColors; i++) {
        this.colorInputs.push('');
      }
      console.log(this.numOfColors);
      

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
      this.colorInputs.splice(index, 1);

    }
    else if(s==="Tag"){
      this.TagsInput.splice(index, 1);


    }
  }
  
  Add(){
    console.log(this.colorInputs);
    console.log(this.numOfColors)
    console.log();

    
  }

  
}

