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
  
  public faStar = faStar;
  public faWineBottle = faWineBottle;
  public faMinus = faMinus;
  public faPlus = faPlus;

  constructor(
    private cardService: CardService
  ) { }

  ngOnInit(): void {
  }

  public addToCard() {

  }

  public increment() {

  }

  public dicrement() {

  }
}
