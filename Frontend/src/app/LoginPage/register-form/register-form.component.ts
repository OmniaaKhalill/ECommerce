import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router, RouterLink } from '@angular/router';


@Component({
  selector: 'app-register-form',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,RouterLink],
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.css'
})
export class RegisterFormComponent implements OnInit {
  userRegisterFrom: FormGroup;

  constructor(private fb: FormBuilder,public accountRepo:AccountService,public router :Router) {

    this.userRegisterFrom = fb.group({

      displayName:['', [Validators.required]],
      email: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      ConfirmPassword: ['', [Validators.required, Validators.minLength(8)]],
    }, { validators: this.confirmPasswordValidator.bind(this) }); // Bind the method to the class instance
  }

  ngOnInit(): void {
    // throw new Error('Method not implemented.');
  }

  confirmPasswordValidator(control: AbstractControl) {
    return control.get('password')?.value === control.get('ConfirmPassword')?.value ?
      null : { PasswordNoMatch: true };
  }

 
    onSubmit() {
      
      console.log(this.userRegisterFrom.get('email')?.value,this.userRegisterFrom.get('password')?.value)   ;

      this.accountRepo.register(this.userRegisterFrom.get('displayName')?.value,this.userRegisterFrom.get('email')?.value, this.userRegisterFrom.get('password')?.value)
      this.router.navigateByUrl("/home")
     }
}
