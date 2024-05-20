import { CommonModule } from '@angular/common';
import { Component, OnInit, output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { User } from '../../models/user';
import { AccountService } from '../../services/account.service';
import { Router, RouterLink } from '@angular/router';
import { order } from '../../models/order';
import { shippingAddress } from '../../models/shipping-address';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [[ReactiveFormsModule,CommonModule,PageHeaderComponent, FormsModule,RouterLink ]],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})

export class OrderComponent implements OnInit {


  
  shippingAddress = new shippingAddress("John", "Doe", "123 Main St", "Springfield", "USA");

  order:order


  constructor(private fb: FormBuilder, public acountRepo:AccountService,public router :Router, public orderService:OrderService) {
    this.order = new order(this.user.Email, this.user.UserId, this.shippingAddress);
  
  }
  

  user = this.acountRepo.getClaims();

  ngOnInit(): void {
   
  }




  onSubmit( ) {
   
  this.orderService.createOrder(this.order).then((success) => {
      if (success) {
        this.router.navigateByUrl("/order/OrderCreated")
      } 
    });
    
    this.router.navigateByUrl("/order/OrderCreated")

   
  }

  

}
