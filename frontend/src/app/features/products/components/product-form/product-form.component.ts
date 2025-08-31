import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  CreateUpdateProduct,
  Product,
} from 'src/app/core/models/product.model';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
})
export class ProductFormComponent implements OnInit, OnChanges {
  productForm: FormGroup;

  @Input() productToEdit: Product | null = null;

  @Output() save = new EventEmitter<CreateUpdateProduct>();

  @Output() cancel = new EventEmitter<void>();

  public formTitle = 'Crear Nuevo Producto';

  constructor(private fb: FormBuilder) {
    this.productForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.maxLength(255)]],
      price: [null, [Validators.required, Validators.min(0.01)]],
    });
  }

  ngOnInit(): void {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['productToEdit'] && this.productToEdit) {
      this.formTitle = 'Editar Producto';
      this.productForm.patchValue(this.productToEdit);
    } else {
      this.formTitle = 'Crear Nuevo Producto';
    }
  }

  onSubmit(): void {
    if (this.productForm.invalid) {
      this.productForm.markAllAsTouched();
      return;
    }
    this.save.emit(this.productForm.value);
  }

  onCancel(): void {
    this.cancel.emit();
  }

  public resetForm(): void {
    this.productForm.reset();
    this.formTitle = 'Crear Nuevo Producto';
  }

  get name() {
    return this.productForm.get('name');
  }

  get description() {
    return this.productForm.get('description');
  }

  get price() {
    return this.productForm.get('price');
  }
}
