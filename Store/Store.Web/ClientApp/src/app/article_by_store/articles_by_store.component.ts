import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticleModel } from '../repository/model';
import { ArticlesService } from '../repository/services';

@Component({
  selector: 'app-articles-by-store',
  templateUrl: './articles_by_store.component.html'
})
export class ArticlesByStoreComponent implements OnInit {

  public total = 0;
  articles: ArticleModel[];
  idStore: number
  loading: boolean;

  constructor(private _service: ArticlesService, private route: ActivatedRoute) {
    this.articles = [];
    this.loading = false;
    this.idStore = 0;
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.idStore = + params['id_store']; // (+) converts string 'id' to a number

    });
  }

  getAllStores() {
    this._service.getArticlesByStore(this.idStore).subscribe(data => {
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

