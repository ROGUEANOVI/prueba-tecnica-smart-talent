import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductsComponent } from './products.component';

@NgModule({
  declarations: [ProductsComponent, ProductListComponent],
  imports: [CommonModule, ProductsRoutingModule, SharedModule],
  exports: [ProductsComponent, ProductListComponent],
})
export class ProductsModule {}
