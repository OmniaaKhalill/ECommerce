import { CommonModule, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';



@Component({
  selector: 'app-profile-details',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './profile-details.component.html',
  styleUrl: './profile-details.component.css'
})
export class ProfileDetailsComponent {
  profiledetailsForm:FormGroup=new FormGroup({
    DisplayName: new FormControl(),
    UserName: new FormControl(),
    Password: new FormControl(),
    ConfirmPassword: new FormControl(),
    Address: new FormControl(),
    PhoneNumber: new FormControl(),
    
 
  })
  onSubmit(form :FormGroup ) {
    console.log(this.profiledetailsForm.value);
  }

}
