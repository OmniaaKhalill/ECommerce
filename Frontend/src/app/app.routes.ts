import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';
import { ShopComponent } from './ShopPage/shop/shop.component';
import { CategoriesPageComponent } from './CategoriesPage/categories-page/categories-page.component';

export const routes: Routes = [
  // { path: "", redirectTo: "home", pathMatch: "full" },
  // { path: "home", component: HomeComponent },
  { path: "", redirectTo: "shop", pathMatch: "full" },
  { path: "shop", component: ShopComponent },
  // { path: "", redirectTo: "category", pathMatch: "full" },
  // { path: "category", component: CategoriesPageComponent },
];
