import { inject, Injectable } from '@angular/core';
import { PagedResponse } from '../models/paged-response.model';
import { CreateUpdateProduct, Product } from '../models/product.model';
import { BehaviorSubject, catchError, EMPTY, Observable, tap } from 'rxjs';
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

  public createProduct(product: CreateUpdateProduct): Observable<void> {
    this.state.next({ ...this.state.value, loading: true });

    return this.http.post<void>(this.apiUrl, product).pipe(
      tap(() => {
        this.getProducts(1, this.state.value.pagedResponse.pageSize);
      }),
      catchError((err) => {
        console.error(err);
        this.state.next({ ...this.state.value, loading: false });
        return EMPTY;
      })
    );
  }

  public getProductById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  public updateProduct(
    id: number,
    product: CreateUpdateProduct
  ): Observable<void> {
    this.state.next({ ...this.state.value, loading: true });

    return this.http.put<void>(`${this.apiUrl}/${id}`, product).pipe(
      tap(() => {
        const currentPage = this.state.value.pagedResponse.pageNumber;
        const pageSize = this.state.value.pagedResponse.pageSize;
        this.getProducts(currentPage, pageSize);
      }),
      catchError((err) => {
        console.error(err);
        this.state.next({ ...this.state.value, loading: false });
        return EMPTY;
      })
    );
  }

  public deleteProduct(id: number): Observable<void> {
    this.state.next({ ...this.state.value, loading: true });

    return this.http.delete<void>(`${this.apiUrl}/${id}`).pipe(
      tap(() => {
        const { pageNumber, pageSize } = this.state.value.pagedResponse;
        this.getProducts(pageNumber, pageSize);
      }),
      catchError((err) => {
        console.error(err);
        this.state.next({ ...this.state.value, loading: false });
        return EMPTY;
      })
    );
  }
}
