import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './components/pagination/pagination.component';
import { FormsModule } from '@angular/forms';
import { ModalComponent } from './components/modal/modal.component';

@NgModule({
  declarations: [PaginationComponent, ModalComponent],
  imports: [CommonModule, FormsModule],
  exports: [PaginationComponent, ModalComponent],
})
export class SharedModule {}
