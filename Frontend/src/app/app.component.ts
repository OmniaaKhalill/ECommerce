import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './core/header/header.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { FooterComponent } from './core/footer/footer.component';
import { PageHeaderComponent } from './ShopPage/page-header/page-header.component';

@Component({
  selector: 'app-root',
  standalone: true,

  imports: [RouterOutlet, HeaderComponent, NavbarComponent, FooterComponent,PageHeaderComponent],



  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'e-commerce';
}
