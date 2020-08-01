import { Component, OnInit } from '@angular/core';
import { faBars, faSearch, faShoppingCart } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public faBars = faBars;
  public faSearch = faSearch;
  public faShoppingCart = faShoppingCart;

  public isOpenedMenu: boolean = false;
  public isOpenedCard: boolean = false;

  public items = [];

  constructor() { }

  ngOnInit(): void {
  }

  public get hasItemsInCard() {
    return this.items.length > 0;
  }

  public get itemsInCard() {
    return this.items;
  }

  public onCloseMenu() {
    this.toggleNavbar();
  }

  public toggleNavbar() {
    this.isOpenedMenu = !this.isOpenedMenu;
  }

  public toggleCard() {
    this.isOpenedCard = !this.isOpenedCard;
  }
}
