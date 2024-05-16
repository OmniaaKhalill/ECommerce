import { CommonModule, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../../Services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../../models/user';



@Component({
  selector: 'app-profile-details',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './profile-details.component.html',
  styleUrl: './profile-details.component.css'
})
export class ProfileDetailsComponent {
  constructor(public userService:UserService , public activatedRoute:ActivatedRoute,public router:Router) {
  
  }
  
  user:User = new User("","","","","","","","");
  ngOnInit():void{
    this.activatedRoute.params.subscribe(p=>{this.userService.GetById(p['id']).subscribe(d=>this.user = d) })
  }

  edit(){
    this.userService.update(this.user).subscribe(d=>{
      this.user= d;
      this.router.navigateByUrl(`/`)
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
