import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from 'src/app/core/services/product.service';
import { CreateUpdateProduct } from 'src/app/core/models/product.model';
import { ProductFormComponent } from './components/product-form/product-form.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
})
export class ProductsComponent implements OnInit {
  public state$ = this.productService.state$;

  @ViewChild(ProductFormComponent) productForm!: ProductFormComponent;

  public isCreateModalOpen = false;

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

  openCreateModal(): void {
    this.isCreateModalOpen = true;
  }

  closeCreateModal(): void {
    this.isCreateModalOpen = false;
    this.productForm?.resetForm();
  }

  onSaveProduct(product: CreateUpdateProduct): void {
    this.productService.createProduct(product).subscribe(() => {
      this.closeCreateModal();
    });
  }
}
