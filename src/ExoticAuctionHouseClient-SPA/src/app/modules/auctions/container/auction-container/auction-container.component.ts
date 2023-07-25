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
export class AuctionContainerComponent implements OnInit {
  public cars: Auction[] = [];

  constructor(private route: ActivatedRoute, private auctionService: AuctionService) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(data => {
      let searchModel: SearchModel = {
        brand: data['brand'],
        model: data['model'],
        fuelType: data['fuelType'],
        bodyType: data['bodyType']
      }

      this.auctionService.getCarsByFilter(searchModel).subscribe(result => {
        console.log(result);
        this.cars = result;
      })
    })
  }
}
