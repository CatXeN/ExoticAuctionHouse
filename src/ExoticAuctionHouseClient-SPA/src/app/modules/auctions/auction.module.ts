import { SharedModule } from '../../shared/shared.module';
import { NgModule } from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import { AuctionContainerComponent } from './container/auction-container/auction-container.component';
import { AuctionRoutingModule } from './auction-routing.module';
import { BodyPipeTranslatorPipe } from './pipe/body-pipe-translator.pipe';
import { FuelPipeTranslatorPipe } from './pipe/fuel-pipe-translator.pipe';
import { CarCardComponent } from './presenter/car-card/car-card.component';

@NgModule({
    imports: [
        CommonModule,
        AuctionRoutingModule,
        SharedModule,
        NgOptimizedImage
    ],
  declarations: [
    AuctionContainerComponent,
    BodyPipeTranslatorPipe,
    FuelPipeTranslatorPipe,
    CarCardComponent
  ],
  exports: [
    BodyPipeTranslatorPipe,
    FuelPipeTranslatorPipe
  ]
})
export class AuctionModule { }
