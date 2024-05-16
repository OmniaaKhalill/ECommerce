import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';
import { ShopComponent } from './ShopPage/shop/shop.component';
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
      { path: 'orders/:id', component: OrdersComponent },
      { path: 'profileDetails/:id', component: ProfileDetailsComponent },
      {path:'sellerprofileDetails',component:SellerPageComponent},
    ],
  },

  { path: "shop", component: ShopComponent },
  { path: "Product", component:ProductsCrudComponent },
  {path:"Add",component:AddProductComponent},
  {path:"Edite/:id",component:EditProductComponent},
  { path: 'home', component: HomeComponent },
  
  { path: 'product/:id', component: SingleProductComponent,children: [
      { path: 'reviews/:id', component: ReviewsComponent },
    { path: 'description/:id', component: DescriptionComponent },
]
}]
  {path:"Cart" , component:CartComponent},
  {path:"WishList" , component:WishListProductsComponent}

];


