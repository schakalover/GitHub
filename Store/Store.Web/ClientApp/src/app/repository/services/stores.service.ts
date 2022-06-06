import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Response } from '../../../core/models/response.model'
import { StoreModel } from '../model';

@Injectable()
export class StoresService {
  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public getAllStores(): Observable<Response<StoreModel>> {
    return this.http.get<Response<StoreModel>>(this._baseUrl + 'stores');
  }
}
