import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CartService } from '../../Services/cart.service';
import { Cart } from '../../models/cart';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../models/product';
import { ProductCart } from '../../models/product-cart';
import { CartItem } from '../../models/cart-item';

@Component({
  selector: 'app-cart-products',
  standalone: true,
  imports: [],
  templateUrl: './cart-products.component.html',
  styleUrl: './cart-products.component.css'
})
export class CartProductsComponent implements OnInit
{
  ProductPrice: number = 84;
  Total: number = this.ProductPrice;
  cart=new Cart();
  ProductList:ProductCart[]=[];
  cartItem:CartItem=new CartItem();
constructor(private cartService:CartService,private productService:ProductService){

}

ngOnInit(): void
{

  this.getCart();
  
}
// getCart()
// {

//   this.cartService.getCartById("d27583dc-4c5c-45b6-9f3b-e759ac95b13d").subscribe(
//     (data)=>{

//       this.cart=data;
//       console.log(data);
//       console.log(this.cart);
//       this.getcartItems()
//       this.print()
//     }
//   )
// }

async getCart()
{
  this.cartService.getCartById("d27583dc-4c5c-45b6-9f3b-e759ac95b13d").subscribe(
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
            quantity:this.cart.items[i].quantity
          });    
          });
    promises.push(promise);
  }
  return Promise.all(promises);}
    
  
// }
// getcartItems(){
//   for(let i=0;i<this.cart.items.length;i++)
//   {

//     this.productService.GetProductCartById(this.cart.items[i].id).subscribe(
//      (data)=>{
//       console.log("hellllllo"+JSON.stringify(data));
//       this.ProductList.push(data);
      
//      } 
//     )
//   }
// }
  
  
  increment(item:ProductCart) {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue + 1;
    item.quantity=newValue;
  
    this.cartItem.id=item.id;
    this.cartItem.price=item.price;
    this.cartItem.quantity=item.quantity;
    this.cartService.update(this.cartItem,"d27583dc-4c5c-45b6-9f3b-e759ac95b13d").subscribe(
      (data)=>{
        console.log("updated cart item"+JSON.stringify(data));
      }
    )
  
    if (newValue <= 10) {
      qtyInput.value = newValue.toString();
      // this.Total = this.ProductPrice * newValue; // Update total
    }
  }
  
  decrement(item:ProductCart) {
    let qtyInput = <HTMLInputElement>document.getElementById('qty');
    let currentValue = parseInt(qtyInput.value);
    let newValue = currentValue - 1;
    item.quantity=newValue;
    this.cartItem.id=item.id;
    this.cartItem.price=item.price;
    this.cartItem.quantity=item.quantity;
    this.cartService.update(this.cartItem,"d27583dc-4c5c-45b6-9f3b-e759ac95b13d").subscribe(
      (data)=>{
        console.log("updated cart item"+JSON.stringify(data));
      })

    if (newValue >= 10) {
      qtyInput.value = newValue.toString();
      // this.Total = this.ProductPrice * newValue; // Update total
    }
  }
  
  print(){
    for(let i=0;i<this.ProductList.length;i++){
      console.log("helo from print"+JSON.stringify(this.ProductList[i]));
    }
  }
  getTotal(item:ProductCart){

    return (item.price*item.quantity)
  }

  delete(item:ProductCart){
    console.log("deleeeeeeeeeeet")
    this.cartItem.id=item.id;
    this.cartItem.price=item.price;
    this.cartItem.quantity=item.quantity;
    this.cartService.delete(this.cartItem,"d27583dc-4c5c-45b6-9f3b-e759ac95b13d").subscribe(
      (data)=>{
        console.log("helllo from delete"+data);
      }
    );
  }
}
