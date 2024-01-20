import { Component } from '@angular/core';
import { AuctionsService } from 'src/app/modules/auctions/services/auctions.service';
import { CarsService } from 'src/app/modules/cars/services/cars.service';
import { UserService } from 'src/app/modules/users/services/user.service';


@Component({
  selector: 'app-dashboard-container',
  templateUrl: './dashboard-container.component.html',
  styleUrls: ['./dashboard-container.component.scss']
})
export class DashboardContainerComponent {

  auctionCount: any;
  carCount: any ;
  userCount: any;
  globalHighestPrice: any = 0;


  constructor(private auctionService: AuctionsService, private carSercice: CarsService, private userService: UserService) {
    this.auctionService.getAllAuctions().subscribe(result => {
      this.auctionCount = result.length;
      const highestPrice = Math.max(...result.map(p => p.currentPrice));
      this.globalHighestPrice = highestPrice;

    });

    this.carSercice.getCars().subscribe(result => {
      this.carCount = result.length;
    });


    this.userService.getUsers().subscribe(result => {
      this.userCount = result.length;
    });


   }

}
