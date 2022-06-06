import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NavMenuComponent } from '.';

@NgModule({
  providers: [],
  declarations: [
    NavMenuComponent
  ],
  imports: [
    RouterModule,
    BrowserModule
  ],
  exports: [
    NavMenuComponent
  ]
})
export class LayoutModule { }
