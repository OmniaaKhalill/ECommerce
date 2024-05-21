import { Component, OnInit } from '@angular/core';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { AccountService } from '../../services/account.service';
import { ProductService } from '../../services/product.service';
import { Wishlist } from '../../models/wishlist';
import { ProductWishlist } from '../../models/product-wishlist';
import { WishlistItem } from '../../models/wishlist-item';
import { WishlistService } from '../../services/wishlist.service';
import { CommonModule } from '@angular/common';
import { Product } from '../../models/product';
import { CartItem } from '../../models/cart-item';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-wish-list-products',
  standalone: true,
  imports: [PageHeaderComponent, CommonModule, FormsModule],
  templateUrl: './wish-list-products.component.html',
  styleUrl: './wish-list-products.component.css'
})
export class WishListProductsComponent implements OnInit {
Pagename: string = "WishList";
  user = this.accountService.getClaims().UserId;
  wishlist: Wishlist = new Wishlist();
  productList: ProductWishlist[] = [];
  wishlistItem: WishlistItem = new WishlistItem(0, 0);
  product: Product = new Product(0, "", 0, 0, [], 0, "", "", [], "", 0, "", 0);
  colors = { colour_name: "", hex_value: "" };
  cartItem: CartItem = new CartItem(this.product.id, 0, this.product.price, this.colors);

  constructor(
    private productService: ProductService,
    private accountService: AccountService,
    private wishlistService: WishlistService,
    public cartService:CartService,
    public router:Router,
  ) {}

  ngOnInit(): void {
    this.GetWishlist();
  }

  GetWishlist(): void {
    this.wishlistService.GetWishlistById(this.user).subscribe({
      next: (data) => {
        this.wishlist = data;
        console.log('Wishlist data:', this.wishlist);
        this.GetWishlistItems();
      },
      error: (err) => {
        console.error('Error fetching wishlist:', err);
      }
    });
  }

  async GetWishlistItems() {
    if (this.wishlist.items && this.wishlist.items.length > 0) {
      const promises = this.wishlist.items.map(item =>
        this.productService.GetProductWishlistById(item.id).toPromise()
          .then(data => {
            if (data) {
              this.productList.push({
                id: data.id,
                name: data.name,
                price: data.price,
                image_link: data.image_link,
                numOfProductInStock: data.numOfProductInStock
              });
            }
          })
      );
      await Promise.all(promises);
      this.Print();
    } else {
      console.log('No items in wishlist');
    }
  }

  Print() {
    console.log('Product List:', this.productList);
  }

  Delete(item: ProductWishlist) {
    console.log("Delete 01");
    this.wishlistService.DeleteWishlist(item, this.user).subscribe({
      next: () => {
        console.log("Delete 06");
        this.productList = this.productList.filter(product => product.id !== item.id);
        console.log('Item deleted:', item);
      },
      error: (err) => {
        console.error('Error deleting item:', err);
      }
    });
  }


  getColor(index: number, event: MouseEvent) {
    event.preventDefault();
    this.colors = this.product.colors[index];
  }

  increment() {
    const qtyInput = <HTMLInputElement>document.getElementById('qty');
    const currentValue = parseInt(qtyInput.value);
    const newValue = currentValue + 1;
    if (newValue <= this.product.numOfProductInStock) {
      qtyInput.value = newValue.toString();
    }
  }

  decrement() {
    const qtyInput = <HTMLInputElement>document.getElementById('qty');
    const currentValue = parseInt(qtyInput.value);
    const newValue = currentValue - 1;
    if (newValue >= 1) {
      qtyInput.value = newValue.toString();
    }
  }

  addToCart() {
    let userid = this.accountService.getClaims().UserId;

    // Get the selected color
    let selectedColor = this.colors;

    // Get the quantity
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let quantity = parseInt(qtyInput.value);

    // Create the CartItem object with color and quantity
    let cartItem: CartItem = new CartItem(
      this.product.id,
      quantity,
      this.product.price,
      selectedColor
    );

    console.log("Product"+JSON.stringify(this.product))
    console.log("AddToCart"+JSON.stringify(cartItem))
    // Add the cart item to the cart service
    this.cartService.addTocart(userid, cartItem).subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigateByUrl("/Cart");
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
}

