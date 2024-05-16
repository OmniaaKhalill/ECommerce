import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {


  isAuth:boolean|undefined;
  constructor(public accountService:AccountService)  {
  
   
  }
  ngOnInit(): void {
 
    
   
   
  }


}
