import { Component, OnChanges, SimpleChanges } from '@angular/core';

import { Router, RouterLink } from '@angular/router';
import { AccountService } from '../../services/account.service';

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
