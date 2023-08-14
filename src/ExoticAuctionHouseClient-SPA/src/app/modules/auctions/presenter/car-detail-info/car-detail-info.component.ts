import { Component, Input } from '@angular/core';
import { AuctionService } from '../../services/auction.service';
import { Auction } from 'src/app/shared/models/auction.model';

@Component({
  selector: 'app-car-detail-info',
  templateUrl: './car-detail-info.component.html',
  styleUrls: ['./car-detail-info.component.scss']
})
export class CarDetailInfoComponent {
  private _auctionId: string = '';
  public auction: Auction | null = null;
  @Input() set auctionId(value: string) {
    if (value !== undefined) {
      this._auctionId = value;

      this.auctionService.getAuction(this._auctionId).subscribe(result => {
        this.auction = result;
        console.log(this.auction);
      });
    }
  }

  constructor(private auctionService: AuctionService) { }
}
