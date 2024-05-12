import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-register-form',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.css'
})
export class RegisterFormComponent implements OnInit {
  userRegisterFrom: FormGroup;

  constructor(private fb: FormBuilder) {
    this.userRegisterFrom = fb.group({
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
    // Handle form submission
  }
}