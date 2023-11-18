import { SharedModule } from '../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {UserPanelRoutingModule} from "./user-panel-routing.module";
import { MainPanelContainerComponent } from './container/main-panel-container/main-panel-container.component';
import { WinnerAuctionPresenterComponent } from './presenter/winner-auction-presenter/winner-auction-presenter.component';
import { PurchasedCarsPresenterComponent } from './presenter/purchased-cars-presenter/purchased-cars-presenter.component';
import { SellCarsPresenterComponent } from './presenter/sell-cars-presenter/sell-cars-presenter.component';
import { MyPaymentsPresenterComponent } from './presenter/my-payments-presenter/my-payments-presenter.component';

@NgModule({
  imports: [
    CommonModule,
    UserPanelRoutingModule,
    SharedModule
  ],
  declarations: [
    MainPanelContainerComponent,
    WinnerAuctionPresenterComponent,
    PurchasedCarsPresenterComponent,
    SellCarsPresenterComponent,
    MyPaymentsPresenterComponent
  ]
})
export class UserPanelModule { }
