import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product } from 'src/app/models/product/product';

@Component({
  selector: 'app-bottle-dialog',
  templateUrl: './bottle-dialog.component.html',
  styleUrls: ['./bottle-dialog.component.scss']
})
export class BottleDialogComponent implements OnInit {
  public product: Product = null;

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: Product
  ) { }

  ngOnInit(): void {
    this.product = this.data;
  }

  
}
