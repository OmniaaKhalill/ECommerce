import { Component } from '@angular/core';
import { CartProductsComponent } from '../cart-products/cart-products.component';

import { CartTotalComponent } from '../cart-total/cart-total.component';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';


@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CartProductsComponent,PageHeaderComponent,CartTotalComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  Pagename:string="Cart";
}
