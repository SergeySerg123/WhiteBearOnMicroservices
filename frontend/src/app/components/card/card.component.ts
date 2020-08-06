import { Component, OnInit, Input, EventEmitter, Output, OnDestroy } from '@angular/core';
import { faTimes, faPlus, faMinus } from '@fortawesome/free-solid-svg-icons';
import { CardService } from 'src/app/services/card.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { CardItem } from 'src/app/models/card/card-item';
import { Product } from 'src/app/models/product/product';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit, OnDestroy {
  public faTimes = faTimes;

  @Input() public isOpenedCard: boolean = false;
  @Output() public toggle = new EventEmitter<void>();

  public items: CardItem[] = new Array<CardItem>();
  
  public unsubscribe$ = new Subject<any>();

  public quantity = 1;

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

  public toggleCard() {
    this.toggle.emit();
  }

  public deleteFromCard(product: Product) {
    this.cardService.deleteFromCard(product);
  }

  public setQuantity(quantity: number) {
    this.quantity = quantity;
  }

  public calcTotalPrice() {

  }
}
