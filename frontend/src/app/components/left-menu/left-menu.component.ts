import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { faTimes } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.scss']
})
export class LeftMenuComponent implements OnInit {
  public faTimes = faTimes;

  @Input() public isOpenedMenu: boolean;
  @Output() public toggle = new EventEmitter<void>();


  constructor() { }

  ngOnInit(): void {
  }

  public toggleNavbar(){
    this.toggle.emit();
  }
}
