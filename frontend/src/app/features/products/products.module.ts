import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ProductsRoutingModule } from './products-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductsComponent } from './products.component';
import { ProductFormComponent } from './components/product-form/product-form.component';

@NgModule({
  declarations: [ProductsComponent, ProductListComponent, ProductFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ProductsRoutingModule,
    SharedModule,
  ],
  exports: [ProductsComponent, ProductListComponent],
})
export class ProductsModule {}
