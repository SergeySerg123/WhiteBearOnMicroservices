import { Component, OnInit } from '@angular/core';
import { faPlus, faMinus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.scss']
})
export class CounterComponent implements OnInit {
  public faMinus = faMinus;
  public faPlus = faPlus;

  public quantity: number = 1;

  constructor() { }

  ngOnInit(): void {
  }

  public dicrement() {

  }

  public increment() {

  }
}
