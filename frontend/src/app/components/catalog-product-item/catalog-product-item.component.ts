import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { faStar, faWineBottle, faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { CardService } from 'src/app/services/card.service';
import { Product } from 'src/app/models/product/product';
import { BottleService } from 'src/app/services/bottle.service';
import { Bottle } from 'src/app/models/bottle/bottle';

@Component({
  selector: 'app-catalog-product-item',
  templateUrl: './catalog-product-item.component.html',
  styleUrls: ['./catalog-product-item.component.scss']
})
export class CatalogProductItemComponent implements OnInit {
  
  @Input() public product: Product = null;
  @Output() public bottleOptions: EventEmitter<Product> = new EventEmitter<Product>();

  public quantity: number = 1;
  
  public faStar = faStar;
  public faWineBottle = faWineBottle;
  public faMinus = faMinus;
  public faPlus = faPlus;

  constructor(
    private cardService: CardService,
    private bottleService: BottleService
  ) { }

  ngOnInit(): void {
  }

  public get description(): string {
    return this.product.description.length <= 25 ? this.product.description
     : this.product.description.substr(0, 25) + '...';
  }

  // Reactions raiting
  public get reactions() {
    let {reactions} = this.product;

    if(reactions === null) {
      return [];
    }

    let reactionsValSum = 0;

    reactions.forEach(r => {
      reactionsValSum += reactionsValSum + r.value;
    });

    let average = Math.floor(reactionsValSum / reactions.length);

    return new Array();
  }

  public addToCard(): void {
    let bottles: Bottle[] = this.bottleService.calcBottles(this.quantity);
    this.cardService.addToCard(this.product, this.quantity, bottles);
  }

  public setQuantity(quantity: number) {
    this.quantity = quantity;
  }

  public openBottleOptions() {
    this.bottleOptions.emit(this.product);
  }
}
