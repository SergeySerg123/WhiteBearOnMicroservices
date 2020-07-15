import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  @Input() public isOpenedCard: boolean = false;
  @Input() public toggleCard: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
