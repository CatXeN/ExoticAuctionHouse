import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuctionContainerComponent } from './container/auction-container/auction-container.component';
import {AuctionDetailContainerComponent} from "./container/auction-detail-container/auction-detail-container.component";

const routes: Routes = [
  {
    path: '',
    component: AuctionContainerComponent
  },
  {
    path: ':id',
    component: AuctionDetailContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuctionRoutingModule {}
