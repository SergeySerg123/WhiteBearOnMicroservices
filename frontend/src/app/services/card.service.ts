import { Injectable } from '@angular/core';
import { Product } from '../models/product/product';
import { Card } from '../models/card/card';
import { CardItem } from '../models/card/card-item';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  private card: Card = null;

  constructor() { }

  public addToCard(product: Product, quantity: number) {
    let newItem: CardItem = {product, quantity};
    this.card.items.push(newItem);
  }

  public deleteFromCard(product: Product) {
    this.card.items = this.card.items.filter((item) => 
      item.product.id !== product.id);
  }
}
