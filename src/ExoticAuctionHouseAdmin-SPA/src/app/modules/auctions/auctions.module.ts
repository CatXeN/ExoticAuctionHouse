import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuctionsRoutingModule } from './auctions-routing.module';
import { AuctionsListContainerComponent } from './container/auctions-list-container/auctions-list-container.component';
import { AuctionsEditContainerComponent } from './container/auctions-edit-container/auctions-edit-container.component';
import { AuctionsListingComponent } from './presenter/auctions-listing/auctions-listing.component';
import { AuctionsDetailsComponent } from './presenter/auctions-details/auctions-details.component';


@NgModule({
  imports: [
    CommonModule,
    AuctionsRoutingModule,
    SharedModule
  ],
  declarations: [
    AuctionsListContainerComponent,
    AuctionsEditContainerComponent,
    AuctionsListingComponent,
    AuctionsDetailsComponent
  ]
})
export class AuctionsModule { }
