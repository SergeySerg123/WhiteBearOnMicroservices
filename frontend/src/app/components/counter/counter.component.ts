import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { faPlus, faMinus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.scss']
})
export class CounterComponent implements OnInit {
  public faMinus = faMinus;
  public faPlus = faPlus;

  @Input() public quantity: number;
  @Output() public quantityEvent = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  public dicrement() {
    if (this.quantity > 0.5) {
      this.quantity -= 0.5;
      this.quantityEvent.emit(this.quantity);
    }
  }

  public increment() {
    this.quantity += 0.5;
    this.quantityEvent.emit(this.quantity);
  }
}
