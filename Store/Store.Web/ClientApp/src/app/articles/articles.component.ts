import { Component } from '@angular/core';
import { ArticleModel } from '../repository/model';
import { ArticlesService } from '../repository/services';

@Component({
  selector: 'app-articles-data',
  templateUrl: './articles.component.html'
})
export class ArticlesComponent {

  public total = 0;
  articles: ArticleModel[];

  loading: boolean;

  constructor(private _service: ArticlesService) {
    this.articles = [];
    this.loading = false;
  }

  getAllStores() {
    this._service.getAllArticles().subscribe(data => {
      if (data.total_elements > 1) {
        this.articles = data.store as ArticleModel[];
      } else {
        this.articles = data.stores as ArticleModel[];
      }

      this.total = data.total_elements;
    }, error => {

    });
  }
}

