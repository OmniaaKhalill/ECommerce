import { Component } from '@angular/core';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';

@Component({
  selector: 'app-wish-list-products',
  standalone: true,
  imports: [PageHeaderComponent],
  templateUrl: './wish-list-products.component.html',
  styleUrl: './wish-list-products.component.css'
})
export class WishListProductsComponent {
  Pagename:string="WishList";
}
