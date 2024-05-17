import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Category } from '../../models/category';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterLink
  ],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent {
  banners = [
    { src: '../../../assets/img/Home/foundation.svg', title: 'Foundation' },

    { src: '../../../assets/img/Home/blush-.svg', title: 'Blusher' },

    { src: '../../../assets/img/Home/lipstick.svg', title: 'Lipstick' },

    { src: '../../../assets/img/Home/eyeliner.svg', title: 'Eyeliner' },

    { src: '../../../assets/img/Home/lip_liner.svg', title: 'Lip Liner' },

    { src: '../../../assets/img/Home/eyeshadow.png', title: 'Eyeshadow' },

    { src: '../../../assets/img/Home/bronzer.svg', title: 'Bronzer' },

    { src: '../../../assets/img/Home/mascara.png', title: 'Mascara' },

    { src: '../../../assets/img/Home/nailpolish.png', title: 'Nail Polish' },

    { src: '../../../assets/img/Home/eyebrow.png', title: 'Eyebrow Pencil' }
  ];
  categories: Category[] = [];
  constructor(private categoryService: CategoryService, private activatedRoute: ActivatedRoute,) { }

  ngOnInit(): void {
    this.categoryService.GetCategories().subscribe(data => {
      this.categories = data;
    });
  }
}
