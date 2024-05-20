import { Component, OnInit } from '@angular/core';
import { Brands } from '../../models/brands';
import { BrandService } from '../../services/brand.service';


@Component({
  selector: 'app-brand-section',
  standalone: true,
  imports: [],
  templateUrl: './brand-section.component.html',
  styleUrl: './brand-section.component.css'
})
export class BrandSectionComponent implements OnInit {
  brand: Brands[] = [];
  constructor(public brandService: BrandService) {}
    ngOnInit() {
      this.brandService.GetBrands().subscribe(data => {
        console.log(data);
        this.brand = data;
      });
    }
}
