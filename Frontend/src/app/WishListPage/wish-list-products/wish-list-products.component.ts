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

@Component({
  selector: 'app-wish-list-products',
  standalone: true,
  imports: [PageHeaderComponent, CommonModule, FormsModule],
  templateUrl: './wish-list-products.component.html',
  styleUrl: './wish-list-products.component.css'
})
export class WishListProductsComponent implements OnInit {
  Pagename:string="WishList";
  user=this.accountService.getClaims().UserId;
  wishlist = new Wishlist();
  productList: ProductWishlist[] = [];
  wishlistItem: WishlistItem = new WishlistItem(0,0);
  product:Product = new Product(0,"",0,0,[],0,"","",[],"",0,"",0);

  constructor(private productService: ProductService, private accountService: AccountService, private wishlistService: WishlistService) {}

  ngOnInit(): void {
      this.GetWishlist();
  }

  async GetWishlist() {
    this.wishlistService.GetWishlistById(this.user).subscribe(
      async (data) => {
        this.wishlist = data;
        console.log(data);
        console.log(this.wishlist);
        await
        this.Print();
      }
    )
  }

  GetWishlistItems() {
    let promises = [];
    for (let i = 0; i < this.wishlist.items.length; i++) {
      let promise = this.productService.GetProductWishlistById(this.wishlist.items[i].id).toPromise()
      .then((data) => {
        console.log("WEEEEEEEEEEEEe" + JSON.stringify(data));
        if(data)
          this.productList.push({
            id: data.id,
            name: data.name,
            price: data.price,
            image_link:data.image_link,
            numOfProductInStock:data.numOfProductInStock
          });
      });
      promises.push(promise);
    }
    return Promise.all(promises);
  }

  Print() {
    for (let i = 0; i < this.productList.length; i++) {
      console.log("This is Print Function" + JSON.stringify(this.productList[i]));
    }
  }

  Delete(item: ProductWishlist) {
    console.log("Delete");
    this.wishlistItem.id = item.id;
    this.wishlistItem.price = item.price;
    console.log("From Delete" + JSON.stringify(this.wishlistItem));
    this.wishlistService.DeleteWishlist(this.wishlistItem, this.user).subscribe(
      (data) => {
        this.productList = this.productList.filter(product => product.id !== item.id);
        console.log("Hello from Delete" + data);
      }
    )
  }
  colors = { colour_name: "", hex_value: "" };
  getColor(index: number, event: MouseEvent) {
    event.preventDefault();
    console.log(this.product.colors[index]);
    this.colors = this.product.colors[index];
  }
  cartItem: CartItem = new CartItem(this.product.id,0,this.product.price,this.colors);
  increment() {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue + 1;
    if (newValue <= this.product.numOfProductInStock) {
      qtyInput.value = newValue.toString();
    }
  }

  decrement() {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue - 1;
    if (newValue >= 1) {
      qtyInput.value = newValue.toString();
    }
  }
  AddToCart() {
    let userid = this.accountService.getClaims().UserId;

  }
}
