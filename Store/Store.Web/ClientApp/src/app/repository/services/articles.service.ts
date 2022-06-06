import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Response } from '../../../core/models/response.model'
import { ArticleModel, StoreModel } from '../model';

@Injectable()
export class ArticlesService {
  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public getAllArticles(): Observable<Response<ArticleModel>> {
    return this.http.get<Response<ArticleModel>>(this._baseUrl + 'Articles');
  }

  public getArticlesByStore(idStore: number): Observable<Response<ArticleModel>> {
    return this.http.get<Response<ArticleModel>>(this._baseUrl + 'Articles/stores/' + idStore);
  }
}
