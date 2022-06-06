import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { StoresComponent } from './stores/stores.component';
import { ArticlesComponent } from './articles/articles.component';
import { LayoutModule } from '../layout';
import { StoresService } from './repository/services/stores.service';
import { ArticlesService } from './repository/services';
import { ArticlesByStoreComponent } from './article_by_store/articles_by_store.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StoresComponent,
    ArticlesComponent,
    ArticlesByStoreComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    LayoutModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'stores', component: StoresComponent },
      { path: 'articles', component: ArticlesComponent },
      { path: 'articles/stores/:id_store', component: ArticlesByStoreComponent },
    ])
  ],
  providers: [
    StoresService,
    ArticlesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
