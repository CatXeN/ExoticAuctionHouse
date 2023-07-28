import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-mobile-menu-list',
  templateUrl: './mobile-menu-list.component.html',
  styleUrls: ['./mobile-menu-list.component.scss']
})
export class MobileMenuListComponent {
  @Output() stateMenuChange = new EventEmitter<boolean>();

  switchMenuState(): void {
    this.stateMenuChange.emit(false);
  }
}
