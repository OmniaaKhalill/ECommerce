import { Component } from '@angular/core';

import { FormComponent } from '../form/form.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [BreadcrumbComponent,FormComponent,PageHeaderComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

}
