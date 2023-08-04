import { SharedModule } from '../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BetRoutingModule } from './bet-routing.module';
import { BetContainerComponent } from './container/bet-container/bet-container.component';
import { BetPanelComponent } from './presenter/bet-panel/bet-panel.component';

@NgModule({
  imports: [
    CommonModule,
    BetRoutingModule,
    SharedModule
  ],
  declarations: [
    BetContainerComponent,
    BetPanelComponent
  ]
})
export class BetModule { }
