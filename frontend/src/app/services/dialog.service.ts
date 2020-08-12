import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BottleDialogComponent } from '../components/bottle-dialog/bottle-dialog.component';
import { Product } from '../models/product/product';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  public constructor(
    private dialog: MatDialog
  ) { }

  public openBottleDialog(product: Product) {
    const dialog = this.dialog.open(BottleDialogComponent, {
      minWidth: '60%',
      data: product
    });
  }
}
