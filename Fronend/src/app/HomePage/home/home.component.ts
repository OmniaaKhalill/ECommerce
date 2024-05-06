import { Component } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { NavbarComponent } from '../../core/navbar/navbar.component';
import { CategoriesComponent } from '../categories/categories.component';
import { OfferSectionComponent } from '../offer-section/offer-section.component';
import { LandingComponent } from '../landing/landing.component';
import { ProductsComponent } from '../products/products.component';
import { BlogsComponent } from '../blogs/blogs.component';
import { ContactUsComponent } from '../contact-us/contact-us.component';
import { FooterComponent } from '../../core/footer/footer.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    HeaderComponent,
    NavbarComponent,
    LandingComponent,
    CategoriesComponent,
    OfferSectionComponent,
    ProductsComponent,
    BlogsComponent,
    ContactUsComponent,
    FooterComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
