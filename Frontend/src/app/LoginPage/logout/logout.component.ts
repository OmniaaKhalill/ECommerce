import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [ ],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent implements OnInit {

 constructor(public accountSercice:AccountService,public router :Router) {

  
 }

  ngOnInit( ): void {
    
      this.accountSercice.logout()
      this.router.navigateByUrl("/login/Signin")
      
  }
  
}
