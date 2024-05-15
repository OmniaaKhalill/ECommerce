import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';
import { ShopComponent } from './ShopPage/shop/shop.component';
import { ProductsCrudComponent } from './SellerPage/products-crud/products-crud.component';
import { AddProductComponent } from './SellerPage/add-product/add-product.component';
import { TabsComponent } from './ProfilePage/tabs/tabs.component';
import { OrdersComponent } from './ProfilePage/content/orders/orders.component';
import { ProfileDetailsComponent } from './ProfilePage/content/profile-details/profile-details.component';
import { SellerPageComponent } from './ProfilePage/content/seller-page/seller-page.component';
import { EditProductComponent } from './SellerPage/edit-product/edit-product.component';

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
import { CanLoginGuard } from './guard/can-login.guard';
import { LogoutComponent } from './LoginPage/logout/logout.component';

export const routes: Routes = [
  
  { path: "home", component: HomeComponent },     //canActivate:[CanLoginGuard],
  { path: "", redirectTo: "login/Signin", pathMatch: "full" },

  { path: "login", component: LoginComponent ,children:[
    { path: "", component: LoginFormComponent},
     { path: "Register", component: RegisterFormComponent},
    { path: "Signin", component: LoginFormComponent}
  ]},

  { path: "logout", component: LogoutComponent},
    { path: "shop", component: ShopComponent },
  { path: "Product", component:ProductsCrudComponent },
  {path:"Add",component:AddProductComponent},
  {path:"Edite/:id",component:EditProductComponent},

  {
    path: 'profile',
    component: TabsComponent,
    children: [
      { path: 'orders', component: OrdersComponent },
      { path: 'profileDetails', component: ProfileDetailsComponent },
      {path:'sellerprofileDetails',component:SellerPageComponent},
    ],
  },


]


];

