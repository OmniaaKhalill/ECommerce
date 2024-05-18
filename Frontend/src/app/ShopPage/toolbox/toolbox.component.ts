import { Component } from '@angular/core';
import { SearchService } from '../../services/search.service';

@Component({
  selector: 'app-toolbox',
  standalone: true,
  imports: [],
  templateUrl: './toolbox.component.html',
  styleUrl: './toolbox.component.css'
})
export class ToolboxComponent {
  searchText = '';

  constructor(private searchService: SearchService) {}

  onSearchChange() {
    this.searchService.setSearchText(this.searchText);
  }
}
