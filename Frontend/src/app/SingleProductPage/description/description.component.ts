import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-description',
  standalone: true,
  imports: [],
  templateUrl: './description.component.html',
  styleUrl: './description.component.css'
})
export class DescriptionComponent {
  constructor(public productService:ProductService , public activatedRoute:ActivatedRoute) {
  
  }
  
 product:Product =  new Product(0,"",0,0,[],0,"","",[],"",0,"")

  ngOnInit():void{
    this.activatedRoute.params.subscribe(p=>{this.productService.GetById(p['id']).subscribe(d=>this.product = d) })
  }
  
}
