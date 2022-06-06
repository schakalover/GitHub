import { Component } from '@angular/core';
import { StoreModel } from '../repository/model';
import { StoresService } from '../repository/services';

@Component({
  selector: 'app-stores-component',
  templateUrl: './stores.component.html'
})
export class StoresComponent {
  public total = 0;
  stores: StoreModel[];

  loading: boolean;

  constructor(private _service: StoresService) {
    this.stores = [];
    this.loading = false;
  }

  getAllStores() {
    this._service.getAllStores().subscribe(data => {
      if (data.total_elements > 1) {
        this.stores = data.article as StoreModel[];
      } else {
        this.stores = data.articles as StoreModel[];
      }

      this.total = data.total_elements;
    }, error => {

    });
  }

}
