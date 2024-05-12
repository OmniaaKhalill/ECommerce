import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';
import { ShopComponent } from './ShopPage/shop/shop.component';

// import { CategoriesPageComponent } from './CategoriesPage/categories-page/categories-page.component';

// export const routes: Routes = [
//   // { path: "", redirectTo: "home", pathMatch: "full" },
//   // { path: "home", component: HomeComponent },
//   // { path: "", redirectTo: "shop", pathMatch: "full" },
//   // { path: "shop", component: ShopComponent },
//   { path: "", redirectTo: "category", pathMatch: "full" },
//   { path: "category", component: CategoriesPageComponent },

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
