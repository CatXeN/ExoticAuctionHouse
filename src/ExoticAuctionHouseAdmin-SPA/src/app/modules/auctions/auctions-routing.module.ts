import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuctionsEditContainerComponent } from './container/auctions-edit-container/auctions-edit-container.component';

const routes: Routes = [
  {
    path: '',
    component: AuctionsEditContainerComponent
  },
  {
    path: 'edit/:id',
    component: AuctionsEditContainerComponent
  },
  {
    path: 'edit',
    component: AuctionsEditContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuctionsRoutingModule {}
