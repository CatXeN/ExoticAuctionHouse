import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Auction } from 'src/app/shared/models/auction.model';
import { AuctionsService } from '../../services/auctions.service';
import { FormBuilder, Validators } from '@angular/forms';
import { SnackbarService } from 'src/app/shared/services/snackbar.service';
import { Car } from 'src/app/shared/models/car.model';
import * as moment from 'moment';
import { CarsService } from 'src/app/modules/cars/services/cars.service';

@Component({
  selector: 'app-auctions-details',
  templateUrl: './auctions-details.component.html',
  styleUrls: ['./auctions-details.component.scss']
})
export class AuctionsDetailsComponent implements OnInit {
  public auction: Auction | null = null;
  public car: Car | null = null;
  public momento: any = null;
  public cars: Car[] = [];

  @Input() set _auction(value: Auction | null) {
    if (value) {
      this.auction = value;

      this.auctionForm.patchValue({
        id: this.auction.id,
        amountStarting: this.auction.amountStarting,
        currentPrice: this.auction.currentPrice,
        biddingBegins: this.auction.biddingBegins.toString(),
        createdAt: this.auction.createdAt.toString(),
        carId: this.auction.carId,
        location: this.auction.location,
        isEnd: this.auction.isEnd
      });
    }
  }

  auctionForm = this.fb.group({
    id: [''],
    amountStarting: [0, Validators.required],
    currentPrice: [0, Validators.required],
    biddingBegins: ['', Validators.required],
    createdAt: ['', Validators.required],
    carId: ['', Validators.required],
    location: ['', Validators.required],
    isEnd: [true, Validators.required]
  });

  constructor(private fb: FormBuilder, private auctionService: AuctionsService, private snackbarService: SnackbarService, private router: Router, private carsService: CarsService) {}


  ngOnInit(): void {
    this.carsService.getCars().subscribe(result => {
      this.cars = result;
    });
  }

  generateNameOfCar(car: Car): string {
    return `${car.id.substring(0,6)} ${car.brand} ${car.model} ${car.generation}`;
  }

  saveChanges(): void {
    let auction: any = {
      amountStarting: this.auctionForm.get('amountStarting')?.value!,
      currentPrice: this.auctionForm.get('currentPrice')?.value!,
      biddingBegins: moment(this.auctionForm.get('startDate')?.value!),
      createdAt: moment(this.auctionForm.get('creationDate')?.value!),
      carId: this.auctionForm.get('carId')?.value!,
      location: this.auctionForm.get('location')?.value!,
      isEnd: this.auctionForm.get('isEnd')?.value!
    };

    if (!auction.id) {
      this.auctionService.addAuction(auction).subscribe(result => {
        this.snackbarService.alert(result, 'Auction added successfully!');
        this.router.navigate(['/auctions'])
      });
      } else {
        this.auctionService.editAuction(auction).subscribe(result => {
          this.snackbarService.alert("car added successfully", 'Auction edited successfully!');
          this.router.navigate(['/auctions'])
        });
    }
  }
}
