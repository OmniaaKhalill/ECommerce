import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { UserService } from '../../services/user.service';
import { SellerService } from '../../services/seller.service';
import { Seller } from '../../models/seller';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-join-us',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './join-us.component.html',
  styleUrls: ['./join-us.component.css']
})
export class JoinUsComponent implements OnInit {
  profiledetailsForm: FormGroup = new FormGroup("");
  seller: Seller = new Seller("", "", "",0,0);
  sub: Subscription | null = null;
  userid: string = '';

  constructor(
    public userService: UserService,
    public activatedRoute: ActivatedRoute,
    public router: Router,
    public accountService: AccountService,
    public sellerService: SellerService
  ) {}

  ngOnInit(): void {
    // Initialize userid here
    this.userid = this.accountService.getClaims().UserId;

    // Initialize the form with the userid
    this.profiledetailsForm = new FormGroup({
      IDImgUrl: new FormControl(),
      userid: new FormControl(this.userid),
    });
  }

  onFileChange(event: any) {
    const file = event.target.files[0];
    this.profiledetailsForm.patchValue({
      IDImgUrl: file
    });
  }
  
  addSeller() {
    
    this.seller.idImgUrl = this.profiledetailsForm.value.IDImgUrl;
    this.seller.userId = this.profiledetailsForm.value.userid;

    this.sellerService.AddSeller(this.seller).then((success) => {
      if (success) { 
        this.router.navigateByUrl("/profile/profileDetails")
      } 
    });
    
    ;
  }

  onSubmit(form: FormGroup) {
    console.log(this.profiledetailsForm.value);
    this.addSeller(); 
  }
  
}
