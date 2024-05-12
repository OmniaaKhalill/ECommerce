import { Component } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { NavbarComponent } from '../../core/navbar/navbar.component';
import { FooterComponent } from '../../core/footer/footer.component';
import { PageHeaderComponent } from '../page-header/page-header.component';
import { BreadcrumbComponent } from '../breadcrumb/breadcrumb.component';
import { PageContentComponent } from '../page-content/page-content.component';

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [
    HeaderComponent,
    NavbarComponent,
    PageHeaderComponent,
    BreadcrumbComponent,
    PageContentComponent,
    FooterComponent
  ],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent {

}
