import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';
import { ShopComponent } from './ShopPage/shop/shop.component';
import { ProductsCrudComponent } from './SellerPage/products-crud/products-crud.component';
import { AddProductComponent } from './SellerPage/add-product/add-product.component';
import { TabsComponent } from './ProfilePage/tabs/tabs.component';
import { OrdersComponent } from './ProfilePage/content/orders/orders.component';
import { ProfileDetailsComponent } from './ProfilePage/content/profile-details/profile-details.component';
import { SellerPageComponent } from './ProfilePage/content/seller-page/seller-page.component';

export const routes: Routes = [
  // { path: "", redirectTo: "home", pathMatch: "full" },
  { path: 'home', component: HomeComponent },
  /*  { path: "", redirectTo: "shop", pathMatch: "full" },
  { path: "shop", component: ShopComponent }, */

  
  {
    path: '',
    component: TabsComponent,
    children: [
      { path: 'orders', component: OrdersComponent },
      { path: 'profileDetails', component: ProfileDetailsComponent },
      {path:'sellerprofileDetails',component:SellerPageComponent},
    ],
  },
  { path: "shop", component: ShopComponent },
  { path: "Product", component:ProductsCrudComponent },
  {path:"Add",component:AddProductComponent}

]

