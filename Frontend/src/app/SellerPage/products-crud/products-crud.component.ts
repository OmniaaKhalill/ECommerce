import { Component, output,EventEmitter, OnInit } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { PaginationComponent } from '../pagination/pagination.component';
import { RouterLink } from '@angular/router';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { ProductRead } from '../../models/product-read';
import { SellerProductsService } from '../../services/seller-products.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { CommonModule } from '@angular/common';
import { AccountService } from '../../services/account.service'

@Component({
  selector: 'app-products-crud',
  standalone: true,
  imports: [PageHeaderComponent,PaginationComponent,RouterLink,BreadcrumbComponent,NgxPaginationModule,CommonModule],
  templateUrl: './products-crud.component.html',
  styleUrl: './products-crud.component.css'
})
export class ProductsCrudComponent implements OnInit
{
Pagename:string="Products";
countPerPage=6;
totalCount=1;
CurrentPageNum=1;
items:ProductRead[]=[]
constructor(private sellerProduct:SellerProductsService,public accountService:AccountService){

}
ngOnInit(): void {
  this.getAllProducts(1);
}
getAllProducts( CurrentPageNum:number)
{
  var user=this.accountService.claims;
  console.log(user);
  this.sellerProduct.getSellerProducts("d27583dc-4c5c-45b6-9f3b-e759ac95b13d",CurrentPageNum,this.countPerPage).subscribe(
    data=>{

      this.totalCount=data.totalCount;
      this.items=data.items;
      console.log(data);
    }
  )

}

// Getpage(e:event){

// }


}
