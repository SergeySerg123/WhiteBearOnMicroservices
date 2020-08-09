import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/products.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Product } from 'src/app/models/product/product';
import { DialogService } from 'src/app/services/dialog.service';
import { BottleService } from 'src/app/services/bottle.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent implements OnInit {

  public unsubscribe$ = new Subject<any>();

  public products: Product[] = null;

  constructor(
    private productsService: ProductsService,
    private dialogService: DialogService,
    private bottleService: BottleService
  ) { }

  ngOnInit(): void {
    this.loadCategories();
    this.loadProducts();
    this.bottleService.loadBottles();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public loadCategories() {

  }

  public loadProducts() {
    this.productsService.getProducts()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((resp) => {
        if(resp.ok) {
          this.products = resp.body as Product[];
        }
      }, (err) => {});
  }

  public openBottleOptions(product: Product) {
    this.dialogService.openBottleDialog(product);
  }
}
