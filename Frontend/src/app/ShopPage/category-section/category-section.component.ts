import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/category';
import { CategoryService } from '../../Services/category.service';

@Component({
  selector: 'app-category-section',
  standalone: true,
  imports: [],
  templateUrl: './category-section.component.html',
  styleUrl: './category-section.component.css'
})
export class CategorySectionComponent implements OnInit {

  categories: Category[] = [];
  constructor(public categoryService: CategoryService) {}
  isBrandsObject(brands: any): boolean {
    return typeof brands === 'object';
  }

    ngOnInit() {
      this.categoryService.GetCategories().subscribe(data => {
        console.log(data);
        this.categories = data;
      });
    }
}