import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {AuctionService} from "../../services/auction.service";
import {SearchModel} from "../../../../shared/models/search.model";
import {Car} from "../../../../shared/models/car.model";
import {Auction} from "../../../../shared/models/auction.model";

@Component({
  selector: 'app-auction-container',
  templateUrl: './auction-container.component.html',
  styleUrls: ['./auction-container.component.scss']
})
export class AuctionContainerComponent {

}
