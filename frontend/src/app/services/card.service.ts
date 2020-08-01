import { Injectable } from '@angular/core';
import { Product } from '../models/product/product';
import { Card } from '../models/card/card';
import { CardItem } from '../models/card/card-item';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  public card$: BehaviorSubject<Card> = null;

  constructor() { }

  public addToCard(product: Product, quantity: number) {
    let newItem: CardItem = {product, quantity};
    var card = this.card$.value;

    let item = card.items.find((item) => item.product.id === product.id);
    
    if(!item === null && !item === undefined) {
      item.quantity += quantity;
    } else {
      card.items.push(newItem);
    }    
    this.card$.next(card);
  }

  public deleteFromCard(product: Product) {
    this.card.items = this.card.items.filter((item) => 
      item.product.id !== product.id);
  }
}
