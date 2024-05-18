import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../models/product';

@Pipe({
  name: 'search',
  standalone: true
})
export class SearchPipe implements PipeTransform {
  transform(products: Product[], searchText: string): Product[] {
    if (!products || !searchText) {
      return products;
    }
    return products.filter(product =>
      product.name.toLowerCase().includes(searchText.toLowerCase())
    );
  }

}
