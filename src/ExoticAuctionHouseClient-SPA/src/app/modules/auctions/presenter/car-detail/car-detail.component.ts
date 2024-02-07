import { Component, Input } from '@angular/core';
import { Auction } from "../../../../shared/models/auction.model";
import { AuctionService } from "../../services/auction.service";
import { CreatePayment } from "../../../../shared/models/create-payment";
import { environment } from "../../../../../environments/environment";
import { SnackbarService } from "../../../../shared/services/snackbar.service";
import { SetFavorite } from "../../../../shared/models/set-favorite.model";
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.scss'],
  animations: [
    trigger(
      'enterAnimation', [
        transition(':enter', [
          style({transform: 'translateX(100%)', opacity: 0}),
          animate('500ms', style({transform: 'translateX(0)', opacity: 1}))
        ]),
        transition(':leave', [
          style({transform: 'translateX(0)', opacity: 1}),
          animate('500ms', style({transform: 'translateX(100%)', opacity: 0}))
        ])
      ]
    )
  ],
})
export class CarDetailComponent {
  auction: Auction | undefined;
  private _auctionId: string = '';
  public images = [''];
  public currentImage: number = 0;
  public loggedIn: boolean = false;
  public isFavorite: boolean = false;
  public left: any;

  constructor(private auctionService: AuctionService, private snackBar: SnackbarService) {
    this.loggedIn = this.localStorage.getItem('token') != null;
  }

  @Input() set auctionId(value: Auction | undefined) {
    if (value !== undefined) {
      this.auction = value;
      this.images = this.auction.car.images.split(',');

      if (this.loggedIn) {
        this.auctionService.getIsFavorite(this.auction.carId!, this.localStorage.getItem('id')!).subscribe(result => {
          this.isFavorite = result;
        });
      }


      setInterval(() => {
        if (this.auction && this.auction.biddingBegins) {
          let diffrence = new Date(this.auction.biddingBegins).getTime() - new Date().getTime();

          let days = Math.floor(diffrence / (1000 * 60 * 60 * 24));
          diffrence -= days * (1000 * 60 * 60 * 24);

          let hours = Math.floor(diffrence / (1000 * 60 * 60));
          diffrence -= hours * (1000 * 60 * 60);

          let minutes = Math.floor(diffrence / (1000 * 60));

          this.left = {
            days: days,
            hours: hours,
            minutes: minutes
          };
        }
      }, 1000);
    }
  }

  public setFullName(): string {
    return `${this.auction?.car.brand} ${this.auction?.car.model} ${this.auction?.car.generation}`;
  }

  public createPayment(): void {
    let payment: CreatePayment = {
      auctionId: this.auction?.id!,
      clientId: localStorage.getItem('id')!
    }

    this.auctionService.createPayment(payment).subscribe(
      {
        next: result => {
          if (environment.production) {
            location.href = "https://payment.exoticah.pl/method/" + result;
          } else {
            location.href = 'http://localhost:4202/method/' + result;
          }
        },
        error: err => {
          console.log(err);
          this.snackBar.alert(err.error, "Ok!");
        }
      }
    );
  }

  public IsActive(): boolean {
    if (!this.auction) {
      return false;
    }

    return new Date(this.auction?.biddingBegins).getTime() < new Date().getTime();
  }

  public changeImage(index: number): void {
    if ((this.currentImage === 0 && index === -1) || (this.currentImage === this.images.length - 1 && index === 1)) {
      return;
    }

    this.currentImage += index;
  }

  public setFavorite(): void {
    let fav: SetFavorite = {
      carId: this.auction?.car.id!,
      clientId: this.localStorage.getItem('id')!
    }

    this.auctionService.setFavorite(fav).subscribe(res => {
      this.isFavorite = !this.isFavorite;
    });
  }

  protected readonly localStorage = localStorage;
}
