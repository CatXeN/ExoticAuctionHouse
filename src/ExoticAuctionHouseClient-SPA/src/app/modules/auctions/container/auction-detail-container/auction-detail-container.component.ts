import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, ParamMap} from "@angular/router";
import { switchMap } from 'rxjs/operators';
import {AuctionService} from "../../services/auction.service";
import {Auction} from "../../../../shared/models/auction.model";

@Component({
  selector: 'app-auction-detail-container',
  templateUrl: './auction-detail-container.component.html',
  styleUrls: ['./auction-detail-container.component.scss']
})
export class AuctionDetailContainerComponent implements OnInit{
  auctionId: string = '';
  public auction: Auction | undefined;

  constructor(private route: ActivatedRoute, private auctionService: AuctionService) {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.auctionId = params.get('id') || '';

      this.auctionService.getAuction(this.auctionId).subscribe(result => {
        this.auction = result;
      });
    })
  }
}
