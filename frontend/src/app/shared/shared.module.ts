import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './components/pagination/pagination.component';
import { FormsModule } from '@angular/forms';
import { ModalComponent } from './components/modal/modal.component';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';

@NgModule({
  declarations: [PaginationComponent, ModalComponent, ConfirmDialogComponent],
  imports: [CommonModule, FormsModule],
  exports: [PaginationComponent, ModalComponent, ConfirmDialogComponent],
})
export class SharedModule {}
