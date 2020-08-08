import { Injectable } from '@angular/core';
import { Product } from '../models/product/product';
import { Card, initialCardState } from '../models/card/card';
import { CardItem } from '../models/card/card-item';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  public card$: BehaviorSubject<Card> = new BehaviorSubject<Card>(
    initialCardState);

  constructor() { }

  public addToCard(product: Product, quantity: number) {
    let newItem: CardItem = {product, quantity};
    var card = this.card$.value;

    let item = card.items.find((item) => item.product.id == product.id);

    if(item !== null && item !== undefined) {
      item.quantity += quantity;
    } else {
      card.items.push(newItem);
    }    
    card.totalPrice = this.calcTotalPrice(card);
    this.card$.next(card);
  }

  public deleteFromCard(product: Product) {
    var card = this.card$.value;

    card.items = card.items.filter((item) => 
      item.product.id !== product.id);

    card.totalPrice = this.calcTotalPrice(card);

    this.card$.next(card);
  }

  private calcTotalPrice(card: Card): number {
    var totalPrice = 0;

    card.items.forEach( (cardItem) => {
      totalPrice += cardItem.product.price * cardItem.quantity;
    } );

    return +totalPrice.toFixed(2);
  }
}
