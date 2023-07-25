import { SharedModule } from '../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuctionContainerComponent } from './container/auction-container/auction-container.component';
import { AuctionRoutingModule } from './auction-routing.module';

@NgModule({
  imports: [
    CommonModule,
    AuctionRoutingModule,
    SharedModule
  ],
  declarations: [
    AuctionContainerComponent
  ]
})
export class AuctionModule { }
