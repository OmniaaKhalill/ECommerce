import { Component, OnInit } from '@angular/core';

import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { AccountService } from '../../services/account.service';
import { Seller } from '../../models/seller';
import { SellerService } from '../../services/seller.service';

@Component({
  selector: 'app-tabs',
  standalone: true,
  imports: [ PageHeaderComponent,
    BreadcrumbComponent,
  RouterOutlet,RouterLink,RouterLinkActive,CommonModule],
  templateUrl: './tabs.component.html',
  styleUrl: './tabs.component.css'
})
export class TabsComponent {
  isSeller: boolean = false;

  seller:Seller =  new Seller("","","",0,0);
 
  constructor(public accountService: AccountService, public sellerService: SellerService) {}

  ngOnInit() {
   
    this.isSeller = this.accountService.getClaims().IsSeller === 'true';
    let userid = this.accountService.getClaims().UserId;
    this.sellerService.getSellerByUserId(userid).subscribe(
      data => {
        this.seller  = data;
      },
      err => {
        console.log(err);
      }
    );
  }
}
