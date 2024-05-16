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
import { SingleProductComponent } from './SingleProductPage/single-product/single-product.component';
import { DescriptionComponent } from './SingleProductPage/description/description.component';
import { ReviewsComponent } from './SingleProductPage/reviews/reviews.component';


export const routes: Routes = [
  // { path: "", redirectTo: "home", pathMatch: "full" },
  /*  { path: "", redirectTo: "shop", pathMatch: "full" },
  { path: "shop", component: ShopComponent }, */

  
  {
    path: '',
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

