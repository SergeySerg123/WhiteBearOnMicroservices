import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  public faTimes = faTimes;

  @Input() public isOpenedCard: boolean = false;
  @Output() public toggle: EventEmitter<void> = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

  public toggleCard() {
    this.toggle.emit();
  }
}
