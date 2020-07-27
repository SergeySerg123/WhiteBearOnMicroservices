import { Component, OnInit, Input } from '@angular/core';
import { faTimes } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.scss']
})
export class LeftMenuComponent implements OnInit {
  public faTimes = faTimes;

  @Input() public isOpenedMenu: boolean = false;
  @Input() public navbarToggle: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  public toggle(){

  }

}
