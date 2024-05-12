import { Component } from '@angular/core';
import { CategoriesComponent } from '../categories/categories.component';
import { OfferSectionComponent } from '../offer-section/offer-section.component';
import { LandingComponent } from '../landing/landing.component';
import { ProductsComponent } from '../products/products.component';
import { BlogsComponent } from '../blogs/blogs.component';
import { ContactUsComponent } from '../contact-us/contact-us.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    LandingComponent,
    CategoriesComponent,
    OfferSectionComponent,
    ProductsComponent,
    BlogsComponent,
    ContactUsComponent,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
