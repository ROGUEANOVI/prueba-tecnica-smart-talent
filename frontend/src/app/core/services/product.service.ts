import { inject, Injectable } from '@angular/core';
import { PagedResponse } from '../models/paged-response.model';
import { Product } from '../models/product.model';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

interface ProductState {
  pagedResponse: PagedResponse<Product>;
  loading: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private readonly apiUrl = `${environment.API_URL}/products`;

  private http: HttpClient = inject(HttpClient);

  private state = new BehaviorSubject<ProductState>({
    pagedResponse: {
      data: [],
      pageNumber: 1,
      pageSize: 10,
      totalPages: 1,
      totalRecords: 0,
    },
    loading: false,
  });

  public state$: Observable<ProductState> = this.state.asObservable();

  public getProducts(pageNumber: number = 1, pageSize: number = 10) {
    this.state.next({ ...this.state.value, loading: true });

    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());

    return this.http
      .get<PagedResponse<Product>>(this.apiUrl, { params })
      .pipe(
        tap((response) => {
          this.state.next({ pagedResponse: response, loading: false });
        })
      )
      .subscribe();
  }
}
