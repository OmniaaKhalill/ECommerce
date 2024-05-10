import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule,Validators } from '@angular/forms';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';


@Component({
  selector: 'app-edit-product',
  standalone: true,
  imports:  [FormsModule,CommonModule,PageHeaderComponent,BreadcrumbComponent,ReactiveFormsModule],
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent {

  Pagename:string="Edite Products";
  numOfColors: number=0;
  colorInputs: string[] = [];
  numOfTags:number=0;
  TagsInput:string[]=[];
  imageUrl: string | ArrayBuffer | null = null;
 


  

  generateInputs(Name:string) {
    if(Name==="color"){
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
    }

  }

  removeInput(index: number,s:string) {
    if(s==="color"){
      this.colorInputs.splice(index, 1);

    }
    else if(s==="Tag"){
      this.TagsInput.splice(index, 1);


    }
  }
}
