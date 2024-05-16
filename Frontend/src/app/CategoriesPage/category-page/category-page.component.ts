import { Component } from '@angular/core';
import { PageHeaderComponent } from '../../ShopPage/page-header/page-header.component';
import { BreadcrumbComponent } from '../../ShopPage/breadcrumb/breadcrumb.component';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoryService } from '../../Services/category.service';
import { Category } from '../../models/category';

@Component({
  selector: 'app-category-page',
  standalone: true,
  imports: [
    PageHeaderComponent,
    BreadcrumbComponent,
    RouterLink,
    CommonModule,
    FormsModule
  ],
  templateUrl: './category-page.component.html',
  styleUrl: './category-page.component.css'
})
export class CategoryPageComponent {
  PageName:string="Categories";
  bannersOne = [
    { src: '../../../assets/img/Category/col1/4.png', title: 'Foundation' },
    { src: '../../../assets/img/Category/col2/6.png', title: 'Blusher' },
    { src: '../../../assets/img/Category/col1/3.png', title: 'Lipstick' },
    { src: '../../../assets/img/Category/col2/2.png', title: 'Eyeliner' },
    { src: '../../../assets/img/Category/col1/1.png', title: 'Lip Liner' }
  ];
  bannersTwo = [
    { src: '../../../assets/img/Category/col2/4.png', title: 'Eyeshadow' },
    { src: '../../../assets/img/Category/col1/5.png', title: 'Bronzer' },
    { src: '../../../assets/img/Category/col2/3.png', title: 'Mascara' },
    { src: '../../../assets/img/Category/col1/2.png', title: 'Nail Polish' },
    { src: '../../../assets/img/Category/col2/5.png', title: 'Eyebrow Pencil' }
  ];
  categories: Category[] = [];

  constructor(private categoryService: CategoryService) { }
  ngOnInit(): void {
    this.categoryService.GetCategories().subscribe(data => {
      this.categories = data;
    });
  }
}
