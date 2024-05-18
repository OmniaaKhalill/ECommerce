import { CommonModule, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../../models/user';
import { AccountService } from '../../../services/account.service';
import { Seller } from '../../../models/seller';



@Component({
  selector: 'app-profile-details',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './profile-details.component.html',
  styleUrl: './profile-details.component.css'
})
export class ProfileDetailsComponent {
  constructor(public userService:UserService , 
    public activatedRoute:ActivatedRoute,public router:Router ,
    public accountService:AccountService,
  
  
  ) {
  
  }
  
  user:User = new User("","","","","","","","");

  ngOnInit():void{
    let userid = this.accountService.getClaims().UserId;
    this.activatedRoute.params.subscribe(p=>{this.userService.GetById(userid).subscribe(d=>this.user = d) })
  }

  edit(){
    this.userService.update(this.user).subscribe(d=>{
      this.user= d;
      this.router.navigateByUrl(`/shop`)
    })
  }

 



  profiledetailsForm:FormGroup=new FormGroup({
    DisplayName: new FormControl(),
    UserName: new FormControl(),
    Password: new FormControl(),
    confirmPassword: new FormControl(),
    Address: new FormControl(),
    PhoneNumber: new FormControl(),
    email: new FormControl(),
    
 
  })
  onSubmit(form :FormGroup ) {
    console.log(this.profiledetailsForm.value);
  }

}
