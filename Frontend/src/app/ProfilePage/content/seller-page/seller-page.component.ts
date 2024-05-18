import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Page } from '../../../models/page';
import { Seller } from '../../../models/seller';
import { User } from '../../../models/user';
import { AccountService } from '../../../services/account.service';
import { PageService } from '../../../services/page.service';
import { SellerService } from '../../../services/seller.service';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-seller-page',
  standalone: true,
  imports: [],
  templateUrl: './seller-page.component.html',
  styleUrl: './seller-page.component.css'
})
export class SellerPageComponent {

  constructor(public userService:UserService , 
    public activatedRoute:ActivatedRoute,public router:Router ,
    public accountService:AccountService,
    public sellerService:SellerService,
    public pageService:PageService
  ) {}

  userId:string = this.accountService.getClaims().UserId;
  user:User = new User("","","","","","","","");
  seller:Seller =  new Seller("","","",0,0);
  page:Page = new Page("","");

  ngOnInit(): void {
    let userid = this.accountService.getClaims().UserId;
    this.sellerService.getSellerByUserId(userid).subscribe(
      data => {
        this.seller = data;
    
        this.pageService.GetPage(this.seller.id).subscribe(
          pageData => {
            this.page = pageData;
            console.log(this.page)
          },
          err => {
            console.log(err);
          }
        );
      },
      err => {
        console.log(err);
      }
    );
  }
  
}
