import { Component, OnInit, OnDestroy } from '@angular/core';
import { faBars, faSearch, faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { CardService } from 'src/app/services/card.service';
import { CardItem } from 'src/app/models/card/card-item';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit, OnDestroy {
  public faBars = faBars;
  public faSearch = faSearch;
  public faShoppingCart = faShoppingCart;

  public isOpenedMenu: boolean = false;
  public isOpenedCard: boolean = false;

  public items: CardItem[] = new Array<CardItem>();

  public unsubscribe$ = new Subject<any>();

  constructor(
    private cardService: CardService
  ) { }

  ngOnInit(): void {
    this.cardService.card$
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(card => {
        this.items = card.items;
      });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public get hasItemsInCard() {
    if (this.items === undefined) {
      return false;
    }
    return this.items.length > 0;
  }

  public get itemsInCard() {
    return this.items.length;
  }

  public toggleNavbar() {
    this.isOpenedMenu = !this.isOpenedMenu;
  }

  public toggleCard() {
    this.isOpenedCard = !this.isOpenedCard;
  }
}
