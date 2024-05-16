import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../Services/account.service';
import { Router, RouterModule } from '@angular/router';


@Component({
  selector: 'app-login-form',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule ],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent implements OnInit {
  userloginFrom: FormGroup;

  constructor(private fb: FormBuilder, public acountRepo:AccountService,public router :Router) {
    this.userloginFrom = fb.group({
      email: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      password: ['', [Validators.required, Validators.minLength(8)]],
     
    }) 
  
  }


  ngOnInit(): void {
    // throw new Error('Method not implemented.');
  }

  


  onSubmit() {
    
    this.acountRepo.login(this.userloginFrom.get('email')?.value, this.userloginFrom.get('password')?.value).then((success) => {
      if (success) {
        this.router.navigateByUrl("/home")
      } 
    });


  }
}
