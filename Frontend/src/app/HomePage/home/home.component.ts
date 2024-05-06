import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { NavbarComponent } from '../navbar/navbar.component';
import { CategoriesComponent } from '../categories/categories.component';
import { OfferSectionComponent } from '../offer-section/offer-section.component';
import { LandingComponent } from '../landing/landing.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    HeaderComponent,
    NavbarComponent,
    LandingComponent,
    CategoriesComponent,
    OfferSectionComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
