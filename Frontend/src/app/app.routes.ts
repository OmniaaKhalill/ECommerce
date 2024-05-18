import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';

import { ProductsCrudComponent } from './SellerPage/products-crud/products-crud.component';
import { AddProductComponent } from './SellerPage/add-product/add-product.component';
import { TabsComponent } from './ProfilePage/tabs/tabs.component';
import { OrdersComponent } from './ProfilePage/content/orders/orders.component';
import { ProfileDetailsComponent } from './ProfilePage/content/profile-details/profile-details.component';
import { SellerPageComponent } from './ProfilePage/content/seller-page/seller-page.component';
import { CartProductsComponent } from './CartPage/cart-products/cart-products.component';
import { CartComponent } from './CartPage/cart/cart.component';
import { WishListProductsComponent } from './WishListPage/wish-list-products/wish-list-products.component';
import { EditProductComponent } from './SellerPage/edit-product/edit-product.component';
import { SingleProductComponent } from './SingleProductPage/single-product/single-product.component';
import { DescriptionComponent } from './SingleProductPage/description/description.component';
import { ReviewsComponent } from './SingleProductPage/reviews/reviews.component';

import { LoginComponent } from './LoginPage/login/login.component';
import { RegisterFormComponent } from './LoginPage/register-form/register-form.component';
import { LoginFormComponent } from './LoginPage/login-form/login-form.component';
import { CanLoginGuard } from './guard/can-login.guard';
import { LogoutComponent } from './LoginPage/logout/logout.component';
import { ProductsComponent } from './HomePage/products/products.component';
import { ShopComponent } from './ShopPage/shop/shop.component';
import { CategoryPageComponent } from './CategoriesPage/category-page/category-page.component';
import { ProductsPageComponent } from './CategoriesPage/products-page/products-page.component';
import { JoinUsComponent } from './ProfilePage/join-us/join-us.component';
import { SellerAddPageFormComponent } from './ProfilePage/seller-add-page-form/seller-add-page-form.component';


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
      { path: 'joinUs', component: JoinUsComponent },
      { path: 'AddPage', component: SellerAddPageFormComponent },
    ],
  },

  { path: "shop", component: ShopComponent },
  { path: "Product", component:ProductsCrudComponent },
  {path:"Add",component:AddProductComponent},
  {path:"Edite/:id",component:EditProductComponent},
  { path: 'home', component: HomeComponent },
  {path:"Cart" , component:CartComponent},
  {path:"WishList" , component:WishListProductsComponent},
     { path: "logout", component: LogoutComponent},
  { path: "product", component: ProductsComponent},
  
  { path: 'product/:id', component: SingleProductComponent,children: [
      { path: 'reviews/:id', component: ReviewsComponent },
    { path: 'description/:id', component: DescriptionComponent },
    
]
},
{ path: "shop", component: ShopComponent },
  { path: "", redirectTo: "category", pathMatch: "full" },
  { path: "category", component: CategoryPageComponent },
  { path: "products-category/:categoryId", component: ProductsPageComponent },


]
