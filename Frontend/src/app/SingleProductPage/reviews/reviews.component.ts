import { Component } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { TimeAgoPipe } from '../../pipes/time-ago.pipe';
import { UserService } from '../../Services/user.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-reviews',
  standalone: true,
  imports: [CommonModule,TimeAgoPipe],
  templateUrl: './reviews.component.html',
  styleUrl: './reviews.component.css'
})
export class ReviewsComponent {
  constructor(public productService:ProductService, public userService :UserService, public activatedRoute:ActivatedRoute) {
  
  }

  product:Product = new Product(0,"","",0,0,[],0,"","",0,[]);
  user:User = new User("","","","","","","","");
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      const productId = params['id'];
      this.productService.GetById(productId).subscribe(product => {
        this.product = product;
        this.fetchUsersForReviews();
      });
    });
  }
  fetchUsersForReviews(): void {
    for (const review of this.product.reviews) {
      this.userService.GetById(review.userId).subscribe(user => {
        review.displayName = user.displayName
        console.log(review.displayName)
      });
    }
  }

}
