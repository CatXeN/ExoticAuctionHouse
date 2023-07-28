import {Component, OnInit} from '@angular/core';
import {Auction} from "../../../../shared/models/auction.model";
import {ActivatedRoute, Router} from "@angular/router";
import {AuctionService} from "../../services/auction.service";
import {SearchModel} from "../../../../shared/models/search.model";

@Component({
  selector: 'app-car-card',
  templateUrl: './car-card.component.html',
  styleUrls: ['./car-card.component.scss']
})
export class CarCardComponent implements OnInit{
  public auctions: Auction[] = [];

  constructor(private route: ActivatedRoute, private auctionService: AuctionService, private router: Router) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(data => {
      if (Object.keys(data).length !== 0) {
        let searchModel: SearchModel = {
          brand: data['brand'],
          model: data['model'],
          fuelType: Number(data['fuelType']),
          bodyType: Number(data['bodyType'])
        }

        this.auctionService.getCarsByFilter(searchModel).subscribe(result => {
          console.log(result);
          this.auctions = result;
        })
      } else {
        this.auctionService.getExhabitedCars().subscribe(result => {
          this.auctions = result;
        });
      }
    })
  }

  showDetail(id: string): void {
    console.log(id);
    this.router.navigate(['panel/auctions', id]);
  }
}
