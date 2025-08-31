import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from 'src/app/core/services/product.service';
import {
  CreateUpdateProduct,
  Product,
} from 'src/app/core/models/product.model';
import { ProductFormComponent } from './components/product-form/product-form.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
})
export class ProductsComponent implements OnInit {
  public state$ = this.productService.state$;

  @ViewChild(ProductFormComponent) productForm!: ProductFormComponent;

  private currentPageSize = 10;

  public isModalOpen = false;

  public selectedProduct: Product | null = null;

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
    this.selectedProduct = null;
    this.isModalOpen = true;
  }

  openEditModal(product: Product): void {
    this.selectedProduct = product;
    this.isModalOpen = true;
  }

  closeModal(): void {
    this.isModalOpen = false;
    this.selectedProduct = null;
    if (this.productForm) {
      this.productForm?.resetForm();
    }
  }

  onSaveProduct(productData: CreateUpdateProduct): void {
    const operation = this.selectedProduct
      ? this.productService.updateProduct(this.selectedProduct.id, productData)
      : this.productService.createProduct(productData);

    operation.subscribe(() => {
      this.closeModal();
    });
  }
}
