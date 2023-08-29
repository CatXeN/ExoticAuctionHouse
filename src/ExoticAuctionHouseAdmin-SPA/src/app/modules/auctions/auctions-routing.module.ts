import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuctionsEditContainerComponent } from './container/auctions-edit-container/auctions-edit-container.component';
import { AuctionsListingComponent } from './presenter/auctions-listing/auctions-listing.component';
import { AuctionsListContainerComponent } from './container/auctions-list-container/auctions-list-container.component';

const routes: Routes = [
  {
    path: '',
    component: AuctionsListContainerComponent
  },
  {
    path: 'auctionedit/:id',
    component: AuctionsEditContainerComponent
  },
  {
    path: 'auctionedit',
    component: AuctionsEditContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuctionsRoutingModule {}
