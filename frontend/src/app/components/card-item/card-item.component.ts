import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CardItem } from 'src/app/models/card/card-item';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { Product } from 'src/app/models/product/product';
import { QuantityChanger } from 'src/app/models/common/quantity-changer.model';

@Component({
  selector: 'app-card-item',
  templateUrl: './card-item.component.html',
  styleUrls: ['./card-item.component.scss']
})
export class CardItemComponent implements OnInit {
  public faTimes = faTimes;

  @Input() public cardItem: CardItem = null;
  @Output() public emitQuantity: EventEmitter<QuantityChanger> = new EventEmitter();
  @Output() public emitDeleteFromCard: EventEmitter<Product> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  public deleteFromCard() {
    this.emitDeleteFromCard.emit(this.cardItem.product);
  }

  public setQuantity(quantity: number, product: Product) {
    this.emitQuantity.emit({quantity, product} as QuantityChanger);
  }

  public parseBottlesAsInformStr(): string {
    let { bottles } = this.cardItem;

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
