import { Injectable } from '@angular/core';
import { Product } from '../models/product/product';
import { Card, initialCardState } from '../models/card/card';
import { CardItem } from '../models/card/card-item';
import { BehaviorSubject } from 'rxjs';
import { Bottle } from '../models/bottle/bottle';
import { additionReducer } from '../helpers/addition.reducer';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  public card$: BehaviorSubject<Card> = new BehaviorSubject<Card>(
    initialCardState);

  constructor() { }

  public addToCard(product: Product, quantity: number, bottles: Bottle[]) {
    let totalBottlesPrice = this.calcCardItemTotalBottlesPrice(bottles);    
    
    var card = this.card$.value;

    let item = card.items.find((item) => item.product.id == product.id);

    if(item !== null && item !== undefined) {
      item.quantity += quantity;
      item.bottles = [...item.bottles, ...bottles];
      item.totalBottlesPrice = item.totalBottlesPrice + totalBottlesPrice;
      item.totalPrice = this.calcCardItemTotalPrice(item.product.price, item.quantity, item.totalBottlesPrice);
    } else {
      let totalPrice =  this.calcCardItemTotalPrice(product.price, quantity, totalBottlesPrice);
      let newItem: CardItem = {product, quantity, bottles, totalBottlesPrice, totalPrice};
      card.items.push(newItem);
    }    
    
    card.totalPrice = this.calcCardTotalPrice(card);
    
    this.card$.next(card);
  }

  public updateQuantityInCard(quantity: number, product: Product, bottles: Bottle[]): CardItem {
    let totalBottlesPrice = this.calcCardItemTotalBottlesPrice(bottles);
    
    var card = this.card$.value;

    let item = card.items.find((item) => item.product.id == product.id);

    if (item !== null && item !== undefined) {
      item.quantity = quantity;
      item.bottles = bottles;
      item.totalBottlesPrice = totalBottlesPrice;
      item.totalPrice = this.calcCardItemTotalPrice(item.product.price, item.quantity, item.totalBottlesPrice);
      card.totalPrice = this.calcCardTotalPrice(card);

      this.card$.next(card);
      return item;
    } 
  }

  public deleteFromCard(product: Product) {
    var card = this.card$.value;

    card.items = card.items.filter((item) => 
      item.product.id !== product.id);

    card.totalPrice = this.calcCardTotalPrice(card);

    this.card$.next(card);
  }

  private calcCardItemTotalBottlesPrice(bottles: Bottle[]): number {
    let totalBottlesPrice = +bottles.reduce(additionReducer).price.toFixed(2);
    return totalBottlesPrice;
  }

  private calcCardItemTotalPrice(productPrice: number, quantity: number, bottlesPrice: number) {
    return +(+(quantity * productPrice).toFixed(2) + bottlesPrice).toFixed(2);
  }

  private calcCardTotalPrice(card: Card): number {
    let totalPrice = 0;
    
    card.items.forEach( (cardItem) => {
      let totalBottlePrice = cardItem.bottles.reduce(additionReducer).price;
      totalPrice += cardItem.product.price * cardItem.quantity + totalBottlePrice;
    } );

    return +totalPrice.toFixed(2);
  }
}
