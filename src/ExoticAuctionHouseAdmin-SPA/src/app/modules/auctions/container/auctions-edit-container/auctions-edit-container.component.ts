import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Auction } from 'src/app/shared/models/auction.model';
import { AuctionsService } from '../../services/auctions.service';

@Component({
  selector: 'app-auctions-edit-container',
  templateUrl: './auctions-edit-container.component.html',
  styleUrls: ['./auctions-edit-container.component.scss']
})
export class AuctionsEditContainerComponent {
  public auction: Auction | null = null;

  constructor(private route: ActivatedRoute, private auctionService: AuctionsService) {
    this.route.params.subscribe(params => {
      if (params['id'] !== undefined) {
        this.auctionService.getAuction(params['id']).subscribe(result => {
          this.auction = result;
        });
      }
    });
  }

}
