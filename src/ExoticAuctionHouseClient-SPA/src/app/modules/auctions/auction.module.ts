import { SharedModule } from '../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuctionContainerComponent } from './container/auction-container/auction-container.component';
import { AuctionRoutingModule } from './auction-routing.module';
import { BodyPipeTranslatorPipe } from './pipe/body-pipe-translator.pipe';
import { FuelPipeTranslatorPipe } from './pipe/fuel-pipe-translator.pipe';

@NgModule({
  imports: [
    CommonModule,
    AuctionRoutingModule,
    SharedModule
  ],
  declarations: [
    AuctionContainerComponent,
    BodyPipeTranslatorPipe,
    FuelPipeTranslatorPipe
  ],
  exports: [
    BodyPipeTranslatorPipe,
    FuelPipeTranslatorPipe
  ]
})
export class AuctionModule { }
