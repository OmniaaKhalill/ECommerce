import { Component } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../models/user';
import { AccountService } from '../../services/account.service';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { SellerService } from '../../services/seller.service';
import { Seller } from '../../models/seller';
import { Page } from '../../models/page';
import { PageService } from '../../services/page.service';

@Component({
  selector: 'app-seller-add-page-form',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './seller-add-page-form.component.html',
  styleUrl: './seller-add-page-form.component.css'
})
export class SellerAddPageFormComponent {
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

  ngOnInit():void{
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

  addPage() {
    this.pageService.AddPage(this.page, this.seller.id).subscribe(
      (response) => {
        this.router.navigateByUrl("/profile/profileDetails");
      },
      (error) => {
        console.error('Error adding page:', error);
      }
    );
  }


  profiledetailsForm:FormGroup=new FormGroup({
    pageDescription: new FormControl(),
    pageName: new FormControl(),
   
 
  })
  onSubmit(form :FormGroup ) {
    console.log(this.profiledetailsForm.value);
  }

}
