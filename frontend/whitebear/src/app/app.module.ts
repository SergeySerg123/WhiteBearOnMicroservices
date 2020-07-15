import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { CardComponent } from './components/card/card.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { BackdropComponent } from './components/backdrop/backdrop.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LeftMenuComponent } from './components/left-menu/left-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    CatalogComponent,
    CardComponent,
    SidebarComponent,
    NavbarComponent,
    BackdropComponent,
    LeftMenuComponent
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
