import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CartService } from '../../services/cart.service';
import { Cart } from '../../models/cart';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { ProductCart } from '../../models/product-cart';
import { CartItem } from '../../models/cart-item';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-cart-products',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart-products.component.html',
  styleUrl: './cart-products.component.css'
})
export class CartProductsComponent implements OnInit
{
   user=this.accountservice.getClaims().UserId;
  ProductPrice: number = 84;
  Total: number = this.ProductPrice;
  cart=new Cart();
  ProductList:ProductCart[]=[];
  colors = { colour_name: "", hex_value: "" };
  cartItem:CartItem=new CartItem(0,0,0,this.colors);
constructor(private cartService:CartService,private productService:ProductService,private accountservice:AccountService){

}

ngOnInit(): void
{

  this.getCart();

}


async getCart()
{
  this.cartService.getCartById(this.user).subscribe(
    async (data)=>{
      this.cart=data;
      console.log(data);
      console.log(this.cart);
      await this.getcartItems();
      this.print();
    }
  )
}
getcartItems(){
  let promises = [];
  for(let i=0;i<this.cart.items.length;i++)
  {
    let promise = this.productService.GetProductCartById(this.cart.items[i].id).toPromise()
      .then((data)=>{
        console.log("hellllllo"+JSON.stringify(data));
        if(data)
          this.ProductList.push({
            id: data.id,
            name: data.name,
            price: data.price,
            image_link:data.image_link,
            quantity:this.cart.items[i].quantity,
            numOfProductInStock:data.numOfProductInStock
          });
          });
    promises.push(promise);
  }
  return Promise.all(promises);}


increment(item: ProductCart, index: number) {
  let qtyInput = <HTMLInputElement>document.getElementById('qty' + index);
  let currentValue = parseInt(qtyInput.value);
  let newValue = currentValue + 1;

  if (newValue <= 10&& item.numOfProductInStock>0) {
    // Update quantity only if it's less than or equal to 10
    item.quantity = newValue;
    item.numOfProductInStock=item.numOfProductInStock-1;
    qtyInput.value = newValue.toString(); // Update input field

    // Update the cart item on the server
    this.cartItem.id = item.id;
    this.cartItem.price = item.price;
    this.cartItem.quantity = item.quantity;
    this.cartService.update(this.cartItem, this.user).subscribe(
      (data) => {
        console.log("updated cart item" + JSON.stringify(data));
      }
    );
  } else {
    // Handle the case where the quantity exceeds the maximum allowed
    console.log("Maximum quantity reached.");
  }
}


decrement(item: ProductCart,index: number) {
  let qtyInput = <HTMLInputElement>document.getElementById('qty' + index);
  let currentValue = parseInt(qtyInput.value);
  let newValue = currentValue - 1;

  // Ensure the new value is greater than or equal to 1 (minimum allowed quantity)
  if (newValue >= 1) {
    item.quantity = newValue; // Update item quantity
    qtyInput.value = newValue.toString(); // Update input field
    item.numOfProductInStock=item.numOfProductInStock+1;
    // Update the cart item on the server
    this.cartItem.id = item.id;
    this.cartItem.price = item.price;
    this.cartItem.quantity = item.quantity;
    console.log("update");
    this.cartService.update(this.cartItem, this.user).subscribe(
      (data) => {
        console.log("Updated cart item: " + JSON.stringify(data));
      }
    );
  } else {
    // Handle the case where the quantity becomes less than 1
    console.log("Minimum quantity reached.");
  }
}



  print(){
    for(let i=0;i<this.ProductList.length;i++){
      console.log("helo from print"+JSON.stringify(this.ProductList[i]));
    }
  }
  getTotal(item:ProductCart){

    const totalPrice = item.price * item.quantity;
    return totalPrice.toFixed(2);
  }

  // increment(item:ProductCart) {
  //   let qtyInput = <HTMLInputElement>document.getElementById('qty');
  //   let currentValue = parseInt(qtyInput.value);
  //   let newValue = currentValue + 1;
  //   item.quantity=newValue;

  //   this.cartItem.id=item.id;
  //   this.cartItem.price=item.price;
  //   this.cartItem.quantity=item.quantity;
  //   this.cartService.update(this.cartItem,this.user).subscribe(
  //     (data)=>{
  //       console.log("updated cart item"+JSON.stringify(data));
  //     }
  //   )

  //   if (newValue <= 10) {
  //     qtyInput.value = newValue.toString();
  //     // this.Total = this.ProductPrice * newValue; // Update total
  //   }
  // }

  // decrement(item:ProductCart) {
  //   let qtyInput = <HTMLInputElement>document.getElementById('qty');
  //   let currentValue = parseInt(qtyInput.value);
  //   let newValue = currentValue - 1;
  //   item.quantity=newValue;
  //   this.cartItem.id=item.id;
  //   this.cartItem.price=item.price;
  //   this.cartItem.quantity=item.quantity;
  //   this.cartService.update(this.cartItem,this.user).subscribe(
  //     (data)=>{
  //       console.log("updated cart item"+JSON.stringify(data));
  //     })

  //   if (newValue >= 10) {
  //     qtyInput.value = newValue.toString();
  //     // this.Total = this.ProductPrice * newValue; // Update total
  //   }
  // }

  // print(){
  //   for(let i=0;i<this.ProductList.length;i++){
  //     console.log("helo from print"+JSON.stringify(this.ProductList[i]));
  //   }
  // }
  // getTotal(item:ProductCart){

  //   return (item.price*item.quantity)
  // }

  delete(item:ProductCart){
    console.log("deleeeeeeeeeeet")
    this.cartItem.id=item.id;
    this.cartItem.price=item.price;
    this.cartItem.quantity=item.quantity;
    console.log("from delete"+JSON.stringify(this.cartItem))
    this.cartService.delete(this.cartItem,this.user).subscribe(
      (data)=>{
        this.ProductList = this.ProductList.filter(product => product.id !== item.id);
        console.log("helllo from delete"+data);
      }
    );
  }
}
