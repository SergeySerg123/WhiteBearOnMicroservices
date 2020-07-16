import { Component, OnInit } from '@angular/core';
import { faStar, faWineBottle, faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { CardService } from 'src/app/services/card.service';

@Component({
  selector: 'app-catalog-product-item',
  templateUrl: './catalog-product-item.component.html',
  styleUrls: ['./catalog-product-item.component.scss']
})
export class CatalogProductItemComponent implements OnInit {
  public faStar = faStar;
  public faWineBottle = faWineBottle;
  public faMinus = faMinus;
  public faPlus = faPlus;

  public img = "../../../assets/pics/blanc.png";

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
