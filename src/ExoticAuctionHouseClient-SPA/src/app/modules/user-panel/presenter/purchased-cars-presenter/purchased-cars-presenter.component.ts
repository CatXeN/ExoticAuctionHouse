import {Component, OnInit} from '@angular/core';
import {UserService} from "../../services/user.service";
import {FollowedCar} from "../../../../shared/models/followed-car.model";
import {AuctionService} from "../../../auctions/services/auction.service";
import {Route, Router} from "@angular/router";

@Component({
  selector: 'app-purchased-cars-presenter',
  templateUrl: './purchased-cars-presenter.component.html',
  styleUrls: ['./purchased-cars-presenter.component.scss']
})
export class PurchasedCarsPresenterComponent implements OnInit {
  public followedCars: FollowedCar[] = [];

  constructor(private userService: UserService, private auctionService: AuctionService, private router: Router) {
  }

  ngOnInit(): void {
    this.userService.getFollowedCars().subscribe(followedCars => {
      this.followedCars = followedCars;
    })
  }

  getAuctionId(carId: string): void {
    this.auctionService.getAuctionIdByCar(carId).subscribe(res => {
      this.router.navigate(['/panel/auctions/' + res])
    })
  }
}
