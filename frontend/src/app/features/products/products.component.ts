import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/core/services/product.service';
import { Observable } from 'rxjs';
import { PagedResponse } from 'src/app/core/models/paged-response.model';
import { Product } from 'src/app/core/models/product.model';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
})
export class ProductsComponent implements OnInit {
  public state$ = this.productService.state$;

  private currentPageSize = 10;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getProducts(1, this.currentPageSize);
  }

  onPageChange(pageNumber: number): void {
    this.productService.getProducts(pageNumber, this.currentPageSize);
  }

  onPageSizeChange(newPageSize: number): void {
    this.currentPageSize = newPageSize;
    this.productService.getProducts(1, this.currentPageSize);
  }
}
