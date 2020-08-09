import { Injectable } from '@angular/core';
import { Product } from '../models/product/product';
import { Card, initialCardState } from '../models/card/card';
import { CardItem } from '../models/card/card-item';
import { BehaviorSubject } from 'rxjs';
import { Bottle } from '../models/bottle/bottle';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  public card$: BehaviorSubject<Card> = new BehaviorSubject<Card>(
    initialCardState);

  constructor() { }

  public addToCard(product: Product, quantity: number, bottles: Bottle[]) {
    let totalBottlesPrice = this.calcCardItemTotalBottlesPrice(bottles);
    
    let newItem: CardItem = {product, quantity, bottles, totalBottlesPrice};
    
    var card = this.card$.value;

    let item = card.items.find((item) => item.product.id == product.id);

    if(item !== null && item !== undefined) {
      item.quantity += quantity;
      item.bottles = [...item.bottles, ...bottles];
      item.totalBottlesPrice = item.totalBottlesPrice + totalBottlesPrice;
    } else {
      card.items.push(newItem);
    }    
    
    card.totalPrice = this.calcCardTotalPrice(card);
    
    this.card$.next(card);
  }

  public deleteFromCard(product: Product) {
    var card = this.card$.value;

    card.items = card.items.filter((item) => 
      item.product.id !== product.id);

    card.totalPrice = this.calcCardTotalPrice(card);

    this.card$.next(card);
  }

  private calcCardItemTotalBottlesPrice(bottles: Bottle[]): number {
    let bottleReducer = (accumulator: Bottle, currentValue: Bottle) => {
      return {capacity: 0, price: accumulator.price + currentValue.price} as Bottle;
    } 
    
    let totalBottlesPrice = bottles.reduce(bottleReducer).price;
    return totalBottlesPrice;
  }

  private calcCardTotalPrice(card: Card): number {
    let totalPrice = 0;

    let bottleReducer = (accumulator: Bottle, currentValue: Bottle) => {
      return {capacity: 0, price: accumulator.price + currentValue.price} as Bottle;
    } 
    
    card.items.forEach( (cardItem) => {
      let totalBottlePrice = cardItem.bottles.reduce(bottleReducer).price;
      totalPrice += cardItem.product.price * cardItem.quantity + totalBottlePrice;
    } );

    return +totalPrice.toFixed(2);
  }
}
