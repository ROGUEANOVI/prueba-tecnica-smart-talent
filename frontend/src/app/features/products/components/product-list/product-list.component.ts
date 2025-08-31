import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Product } from 'src/app/core/models/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
})
export class ProductListComponent {
  @Input() products: Product[] = [];
  // @Output() edit = new EventEmitter<Product>();
  // @Output() delete = new EventEmitter<Product>();
}
