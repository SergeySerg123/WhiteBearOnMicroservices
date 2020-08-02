import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { CardComponent } from './components/card/card.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { BackdropComponent } from './components/backdrop/backdrop.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LeftMenuComponent } from './components/left-menu/left-menu.component';
import { CatalogProductItemComponent } from './components/catalog-product-item/catalog-product-item.component';
import { HttpClientModule } from '@angular/common/http';
import { CounterComponent } from './components/counter/counter.component';

@NgModule({
  declarations: [
    AppComponent,
    CatalogComponent,
    CardComponent,
    NavbarComponent,
    BackdropComponent,
    LeftMenuComponent,
    CatalogProductItemComponent,
    CounterComponent
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
