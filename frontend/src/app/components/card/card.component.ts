import { Component, OnInit, Input, EventEmitter, Output, OnDestroy } from '@angular/core';
import { CardService } from 'src/app/services/card.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { CardItem } from 'src/app/models/card/card-item';
import { Product } from 'src/app/models/product/product';
import { BottleService } from 'src/app/services/bottle.service';
import { Bottle } from 'src/app/models/bottle/bottle';
import { QuantityChanger } from 'src/app/models/common/quantity-changer.model';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import '../../../assets/pics/WB-logo.jpg';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit, OnDestroy {
  public faTimes = faTimes;

  @Input() public isOpenedCard: boolean = false;
  @Output() public toggle = new EventEmitter<void>();

  public totalPrice = 0;
  public hasItems: boolean = false;
  public items: CardItem[] = new Array<CardItem>();
  
  public unsubscribe$ = new Subject<any>();

  constructor(private cardService: CardService,
    private bottleService: BottleService) { }

  ngOnInit(): void {
    this.cardService.card$
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(card => {
        this.totalPrice = card.totalPrice;
        this.items = card.items;
        this.hasItems = this.items.length > 0;
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

  public setQuantity(changer: QuantityChanger) {
    let bottles: Bottle[] = this.bottleService.calcBottles(changer.quantity);
    let updatedItem: CardItem = this.cardService.updateQuantityInCard(changer.quantity, changer.product, bottles);
    let i = this.items.findIndex( (item) => item.product.id === updatedItem.product.id);
    if (i !== -1) {
      this.items.splice(i, 1, updatedItem);
    }
  }
}
