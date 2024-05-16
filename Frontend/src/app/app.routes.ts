import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';
import { ShopComponent } from './ShopPage/shop/shop.component';
import { CategoryPageComponent } from './CategoriesPage/category-page/category-page.component';

export const routes: Routes = [
  // { path: "", redirectTo: "home", pathMatch: "full" },
  // { path: "home", component: HomeComponent },
  // { path: "", redirectTo: "shop", pathMatch: "full" },
  { path: "shop", component: ShopComponent },
  { path: "", redirectTo: "category", pathMatch: "full" },
  { path: "category", component: CategoryPageComponent },
];
