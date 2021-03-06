import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Product } from 'src/app/models/product/product';
import { faTimes, faWineBottle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-bottle-dialog',
  templateUrl: './bottle-dialog.component.html',
  styleUrls: ['./bottle-dialog.component.scss']
})
export class BottleDialogComponent implements OnInit {
  public faTimes = faTimes;
  public faWinesBottle = faWineBottle;

  public product: Product = null;

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: Product,
    private dialogRef: MatDialogRef<BottleDialogComponent>
  ) { }

  ngOnInit(): void {
    this.product = this.data;
  }

  public closeDialog() {
    this.dialogRef.close(false);
  }
}
