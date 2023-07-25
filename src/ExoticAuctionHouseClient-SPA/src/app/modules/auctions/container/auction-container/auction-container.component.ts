import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {AuctionService} from "../../services/auction.service";
import {SearchModel} from "../../../../shared/models/search.model";
import {Car} from "../../../../shared/models/car.model";

@Component({
  selector: 'app-auction-container',
  templateUrl: './auction-container.component.html',
  styleUrls: ['./auction-container.component.scss']
})
export class AuctionContainerComponent implements OnInit {
  public cars: Car[] = [];

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
        this.cars = result;
      })
    })
  }
}
