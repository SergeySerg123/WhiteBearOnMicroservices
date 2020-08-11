import { Component, OnInit, Input, EventEmitter, Output, OnDestroy } from '@angular/core';
import { faTimes, faPlus, faMinus } from '@fortawesome/free-solid-svg-icons';
import { CardService } from 'src/app/services/card.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { CardItem } from 'src/app/models/card/card-item';
import { Product } from 'src/app/models/product/product';
import { BottleService } from 'src/app/services/bottle.service';
import { Bottle } from 'src/app/models/bottle/bottle';

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

  public setQuantity(quantity: number, product: Product) {
    // this.quantity = quantity;
    let bottles: Bottle[] = this.bottleService.calcBottles(quantity);
    let updatedItem: CardItem = this.cardService.updateQuantityInCard(quantity, product, bottles);
    this.parseBottlesAsInformStr(updatedItem);
  }

  public parseBottlesAsInformStr(cardItem: CardItem): string {
    let { bottles } = cardItem;

    let capacityArr: number[] = [];

    bottles.forEach( (bottle) => {
      capacityArr.push(bottle.capacity);
    } );

    var occurrences = { }; // {volume: numbers, volume: numbers...}
    for (var i = 0, j = capacityArr.length; i < j; i++) {
          occurrences[capacityArr[i]] = (occurrences[capacityArr[i]] || 0) + 1;
    }
    
    let props = Object.keys(occurrences).length;
    let count = 0;
    let result: string = props > 1 ? "Бутылки, " : "Бутылка, ";
    for (let volume in occurrences) {
      count++;
      result += `${volume} л. ${occurrences[volume]} шт. ${props === count ? '' : ','}`;
    }

    return result;
  }
}
