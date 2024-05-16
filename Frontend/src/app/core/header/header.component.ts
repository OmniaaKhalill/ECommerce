import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent  {

constructor( public router :Router,public accountSercice:AccountService) {
  

  
}





 

}
