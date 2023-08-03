import { Component } from '@angular/core';
import {MenuState} from "../../../shared/models/menu-state.model";

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent {
  menuState: MenuState = MenuState.closed;

  openMenu($event: boolean): void {
    this.menuState = $event ? MenuState.opened : MenuState.closed;
  }
}
