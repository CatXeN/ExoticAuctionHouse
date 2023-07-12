import { SharedModule } from '../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BetRoutingModule } from './bet-routing.module';
import { BetContainerComponent } from './container/bet-container/bet-container.component';

@NgModule({
  imports: [
    CommonModule,
    BetRoutingModule,
    SharedModule
  ],
  declarations: [
    BetContainerComponent
  ]
})
export class BetModule { }
