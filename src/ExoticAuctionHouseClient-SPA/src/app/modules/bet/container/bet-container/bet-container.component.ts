import {Component, OnInit} from '@angular/core';
import * as signalR from "@microsoft/signalr";
import {HubConnection} from "@microsoft/signalr";
import {ActivatedRoute, ParamMap} from "@angular/router";
import {AuctionService} from "../../../auctions/services/auction.service";
import {Auction} from "../../../../shared/models/auction.model";

@Component({
  selector: 'app-bet-container',
  templateUrl: './bet-container.component.html',
  styleUrls: ['./bet-container.component.scss']
})
export class BetContainerComponent {
  auctionId: string = '';
  auction: Auction | null = null;

  constructor(private auctionService: AuctionService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.auctionId = params.get('id') || '';
    })

    this.auctionService.getAuction(this.auctionId).subscribe(res => {
      this.auction = res;
    });
  }

}
