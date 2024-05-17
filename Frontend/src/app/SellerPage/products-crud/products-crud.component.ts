import { Component, output,EventEmitter, OnInit } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { PaginationComponent } from '../pagination/pagination.component';
import { RouterLink } from '@angular/router';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { ProductRead } from '../../models/product-read';
import { SellerProductsService } from '../../Services/seller-products.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { CommonModule } from '@angular/common';
import { AccountService } from '../../Services/account.service';
import { Product } from '../../models/product';
import { ProductService } from '../../Services/product.service';

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
constructor(private sellerProduct:SellerProductsService,public accountService:AccountService,private prodctService:ProductService){

}
ngOnInit(): void {
  this.getAllProducts(1);
}
getAllProducts( CurrentPageNum:number)
{
  var user=this.accountService.claims?.Email;
  console.log(user);
  this.sellerProduct.getSellerProducts("d27583dc-4c5c-45b6-9f3b-e759ac95b13d",CurrentPageNum,this.countPerPage).subscribe(
    data=>{

      this.totalCount=data.totalCount;
      this.items=data.items;
      console.log(data);
    }
  )

}

get totalPages(): number {
  return Math.ceil(this.totalCount / this.countPerPage);
}

getPages(): (number | string)[] {
  const totalPages = this.totalPages;
  const currentPage = this.CurrentPageNum;
  const maxPagesToShow = 5;
  const pages: (number | string)[] = [];

  if (totalPages <= maxPagesToShow) {
    for (let i = 1; i <= totalPages; i++) {
      pages.push(i);
    }
  } else {
    const half = Math.floor(maxPagesToShow / 2);
    let start = currentPage - half;
    let end = currentPage + half;

    if (start <= 1) {
      start = 1;
      end = maxPagesToShow;
    }

    if (end >= totalPages) {
      start = totalPages - maxPagesToShow + 1;
      end = totalPages;
    }

    for (let i = start; i <= end; i++) {
      pages.push(i);
    }

    if (start > 2) {
      pages.unshift('...');
      pages.unshift(1);
    } else if (start === 2) {
      pages.unshift(1);
    }

    if (end < totalPages - 1) {
      pages.push('...');
      pages.push(totalPages);
    } else if (end === totalPages - 1) {
      pages.push(totalPages);
    }
  }

  return pages;
}

goToPage(page: number | string): void {
  if (typeof page === 'number') {
    if (page >= 1 && page <= this.totalPages) {
      this.CurrentPageNum = page;
      this.getAllProducts(this.CurrentPageNum);
    }
  }
}

PreviousPage(): void {
  if (this.CurrentPageNum > 1) {
    this.goToPage(this.CurrentPageNum - 1);
  }
}

NextPage(): void {
  if (this.CurrentPageNum < this.totalPages) {
    this.goToPage(this.CurrentPageNum + 1);
  }
}


delete(item:ProductRead)
{

  this.prodctService.delete(item.id).subscribe(

    ()=>{
      this.items = this.items.filter(product => product.id !== item.id);
    }
  );
}


}
