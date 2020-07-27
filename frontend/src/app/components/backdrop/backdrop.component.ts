import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-backdrop',
  templateUrl: './backdrop.component.html',
  styleUrls: ['./backdrop.component.scss']
})
export class BackdropComponent implements OnInit {
  
  @Input() public isOpenedMenu: boolean = false;
  @Input() public isOpenedCard: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }
}
