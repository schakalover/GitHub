import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, filter, map, tap } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class HttpErrorInterceptor implements HttpInterceptor {

  private apiURLAcceso: string;

  constructor(private router: Router, private activedRoute: ActivatedRoute,
    private http: HttpClient) {
    this.apiURLAcceso = "";

  }

  intercept(httpRequest: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let request = httpRequest;

    const url: string = httpRequest.url;

    return next.handle(request).pipe(
      tap(
        event => {
          if (event instanceof HttpResponse) {
            console.log(event);
          }
        },
        error => {
          if (error instanceof HttpErrorResponse) {
            console.log('request failed');
          }
        }
      ));
  }

}
