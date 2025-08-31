import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(private toastr: ToastrService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'Ha ocurrido un error inesperado.';

        if (error.error && typeof error.error.detail === 'string') {
          errorMessage = error.error.detail;
        } else if (error.status === 0) {
          errorMessage =
            'No se pudo conectar con el servidor. Por favor, verifica tu conexión.';
        }

        this.toastr.error(errorMessage, `Error ${error.status}`);
        return throwError(() => error);
      })
    );
  }
}
