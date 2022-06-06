import { LOCALE_ID, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


import { registerLocaleData } from '@angular/common';
import localeEsMX from '@angular/common/locales/es-MX';
registerLocaleData(localeEsMX);


@NgModule({
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es-MX' }
  ],
  declarations: [
    
  ],
  exports: [
    //Modulos
    HttpClientModule,
    FormsModule,
    CommonModule,
  ]
})
export class CoreModule { }
