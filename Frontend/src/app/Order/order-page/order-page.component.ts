import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';

@Component({
  selector: 'app-order-page',
  standalone: true,
  imports: [RouterLinkActive,RouterLink,RouterOutlet,PageHeaderComponent],
  templateUrl: './order-page.component.html',
  styleUrl: './order-page.component.css'
})
export class OrderPageComponent {
  Pagename:string="Order";
}
