import { Component, EventEmitter, Output } from '@angular/core';
import { SearchService } from '../../services/search.service';
import { ShopParams } from '../../models/shop-params';
// import { ShopService } from '../../services/shop.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-toolbox',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './toolbox.component.html',
  styleUrl: './toolbox.component.css'
})
export class ToolboxComponent {
  // searchText = '';
  // @Output() sortChanged = new EventEmitter<string>();

  // constructor(private searchService: SearchService, public shopService: ShopService) {}

  // shopParams: ShopParams = new ShopParams();

  // sortOptions = [
  //   { name: 'Alphabetical', value: 'name' },
  //   { name: 'Price: Low to high', value: 'priceAsc' },
  //   { name: 'Price: High to low', value: 'priceDesc' },
  // ];

  // onSortSelected(event: Event) {
  //   const target = event.target as HTMLSelectElement;
  //   const sort = target.value;
  //   this.sortChanged.emit(sort);
  // }

  // onSearchChange() {
  //   this.searchService.setSearchText(this.searchText);
  // }
}
