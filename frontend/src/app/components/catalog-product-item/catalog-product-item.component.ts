import { Component, OnInit, Input } from '@angular/core';
import { faStar, faWineBottle, faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { CardService } from 'src/app/services/card.service';
import { Product } from 'src/app/models/product/product';

@Component({
  selector: 'app-catalog-product-item',
  templateUrl: './catalog-product-item.component.html',
  styleUrls: ['./catalog-product-item.component.scss']
})
export class CatalogProductItemComponent implements OnInit {
  
  @Input() public product: Product = null;

  public quantity: number = 1;
  
  public faStar = faStar;
  public faWineBottle = faWineBottle;
  public faMinus = faMinus;
  public faPlus = faPlus;

  constructor(
    private cardService: CardService
  ) { }

  ngOnInit(): void {
  }

  public get description(): string {
    return this.product.description.length <= 25 ? this.product.description
     : this.product.description.substr(0, 25) + '...';
  }

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
    this.cardService.addToCard(this.product, this.quantity);
  }

  public increment() {

  }

  public dicrement() {

  }
}
