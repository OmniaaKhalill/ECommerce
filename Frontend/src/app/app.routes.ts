import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';
import { ShopComponent } from './ShopPage/shop/shop.component';
import { LoginComponent } from './LoginPage/login/login.component';
import { RegisterFormComponent } from './LoginPage/register-form/register-form.component';
import { LoginFormComponent } from './LoginPage/login-form/login-form.component';

export const routes: Routes = [
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "login", component: LoginComponent ,children:[
    { path: "", component: RegisterFormComponent},
    { path: "Register", component: RegisterFormComponent},
    { path: "Signin", component: LoginFormComponent}
  ]},

  // { path: "", redirectTo: "shop", pathMatch: "full" },
  // { path: "shop", component: ShopComponent },
];
