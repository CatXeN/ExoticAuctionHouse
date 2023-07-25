import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuctionContainerComponent } from './container/auction-container/auction-container.component';

const routes: Routes = [
  {
    path: '',
    component: AuctionContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuctionRoutingModule {}
