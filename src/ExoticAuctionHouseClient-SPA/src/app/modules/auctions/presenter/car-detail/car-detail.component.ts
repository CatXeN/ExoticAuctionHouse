import {Component, Input} from '@angular/core';
import {Auction} from "../../../../shared/models/auction.model";
import {AuctionService} from "../../services/auction.service";

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.scss']
})
export class CarDetailComponent {
  auction: Auction | undefined;
  private _auctionId: string = '';

  constructor(private auctionService: AuctionService) {}

  @Input() set auctionId(value: string) {
    if (value !== undefined) {
      this._auctionId = value;

      this.auctionService.getAuction(this._auctionId).subscribe(result => {
        this.auction = result;
      });
    }
  }

  public setFullName(): string {
    return `${this.auction?.car.brand} ${this.auction?.car.model} ${this.auction?.car.generation}`;
  }
}
