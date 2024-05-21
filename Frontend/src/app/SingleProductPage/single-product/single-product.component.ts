import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';


import { RouterLink, RouterOutlet, ActivatedRoute, Router } from '@angular/router';
import { SimilarProductsComponent } from '../similar-products/similar-products.component';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { CartService } from '../../services/cart.service';
import { AccountService } from '../../services/account.service';
import { CartItem } from '../../models/cart-item';
import { FormsModule } from '@angular/forms';
import { WishlistItem } from '../../models/wishlist-item';
import { WishlistService } from '../../services/wishlist.service';

@Component({
  selector: 'app-single-product',
  standalone: true,
  imports: [CommonModule,RouterLink,RouterOutlet,SimilarProductsComponent,FormsModule],
  templateUrl: './single-product.component.html',
  styleUrl: './single-product.component.css'
})
export class SingleProductComponent {

constructor(public productService:ProductService , public activatedRoute:ActivatedRoute,
  public cartService:CartService,
  public accountService:AccountService,
  public router:Router,
  public wishlistService: WishlistService
) {
}

product:Product = new Product(0,"",0,0,[],0,"","",[],"",0,"",0);
ngOnInit():void{
  if(this.outOfStock()==true){
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    qtyInput.value = "0";
  }

  this.activatedRoute.params.subscribe(p=>{this.productService.GetById(p['id']).subscribe(d=>this.product = d) })
}



  bigImage: string ="../../../assets/img/Home/product1.jpeg"

  preventReload(event: MouseEvent) {

    event.preventDefault();

  }


  outOfStock(): boolean {

    return this.product.numOfProductInStock === 0;

}




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


  activeTab: string = 'description';

  isActive(tab: string): boolean {
    return this.activeTab === tab;
  }

  setActive(tab: string): void {
    this.activeTab = tab;
  }

  colors = { colour_name: "", hex_value: "" };

  getColor(index: number, event: MouseEvent) {
    event.preventDefault();
    console.log(this.product.colors[index]);
    this.colors = this.product.colors[index];
  }



  cartItem: CartItem = new CartItem(this.product.id,0,this.product.price,this.colors);
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


  // AddToWishlist() {
  //   let userid = this.accountService.getClaims().UserId;

  //   let qtyInput = <HTMLInputElement>document.getElementById('qty');
  //   let wishlistItem: WishlistItem = new WishlistItem(
  //     this.product.id,
  //     this.product.price,
  //   );
  //   console.log("Product "+JSON.stringify(this.product));
  //   console.log("AddToWishlist "+JSON.stringify(wishlistItem));
  //   this.wishlistService.AddWishlistItem(userid, wishlistItem).subscribe({
  //     next: (data) => {
  //       console.log(data);
  //       this.router.navigateByUrl("/Wishlist");
  //     },
  //     error: (error) => {
  //       console.log(error);
  //     }
  //   })
  // }


  AddToWishlist() {
    const userId = this.accountService.getClaims().UserId;
    if (!userId) {
      console.log("User ID is missing");
      return;
    }

    const wishlistId = userId;  // assuming wishlistId is the same as userId for simplicity
    const wishlistItem: WishlistItem = new WishlistItem(
      this.product.id,
      this.product.price
    );

    console.log("Product", JSON.stringify(this.product));
    console.log("AddToWishlist", JSON.stringify(wishlistItem));

    if (!wishlistId) {
      console.log("Wishlist ID is missing");
      return;
    }

    this.wishlistService.AddWishlistItem(wishlistId, wishlistItem).subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigateByUrl("/Wishlist");
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
}