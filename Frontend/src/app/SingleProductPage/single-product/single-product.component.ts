import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';


import { RouterLink, RouterOutlet, ActivatedRoute } from '@angular/router';
import { SimilarProductsComponent } from '../similar-products/similar-products.component';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-single-product',
  standalone: true,
  imports: [CommonModule,RouterLink,RouterOutlet,SimilarProductsComponent],
  templateUrl: './single-product.component.html',
  styleUrl: './single-product.component.css'
})
export class SingleProductComponent {

constructor(public productService:ProductService , public activatedRoute:ActivatedRoute) {
  
}

product:Product = new Product(0,"",0,0,[],0,"","",0,[],"",0,"");
ngOnInit():void{
  if(this.outOfStock()==true){
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    qtyInput.value = "0";
  }

  this.activatedRoute.params.subscribe(p=>{this.productService.GetById(p['id']).subscribe(d=>this.product = d) })
}



  bigImage: string ="../../../assets/img/Home/product1.jpeg"

  preventReload(event: MouseEvent) {
   
    event.preventDefault();
    
  }


  outOfStock(): boolean {
   
    return this.product.numOfProductInStock === 0;
    
}




  increment() {
   
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue + 1;
    if (newValue <= this.product.numOfProductInStock) {
      qtyInput.value = newValue.toString();
    }
  }

  decrement() {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue - 1;
    if (newValue >= 1) {
      qtyInput.value = newValue.toString();
    }
  }
  

  activeTab: string = 'description';

  isActive(tab: string): boolean {
    return this.activeTab === tab;
  }

  setActive(tab: string): void {
    this.activeTab = tab;
  }
}
