import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-mobile-menu',
  templateUrl: './mobile-menu.component.html',
  styleUrls: ['./mobile-menu.component.scss']
})
export class MobileMenuComponent {
  @Output() stateMenuChange = new EventEmitter<boolean>();

  switchMenuState() {
    this.stateMenuChange.emit(true);
  }
}
