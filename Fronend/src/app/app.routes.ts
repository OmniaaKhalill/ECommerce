import { Routes } from '@angular/router';
import { HomeComponent } from './HomePage/home/home.component';
import { SingleProductComponent } from './product/single-product/single-product.component';
import { DescriptionComponent } from './product/description/description.component';
import { ReviewsComponent } from './product/reviews/reviews.component';
import { TagsComponent } from './product/tags/tags.component';

export const routes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "home", component: HomeComponent },
   
    { path: 'product', component: SingleProductComponent,children: [
      { path: '', component: DescriptionComponent },
      { path: 'reviews', component: ReviewsComponent },
      { path: 'tags', component: TagsComponent },
     

      ]},
  
];
