import {Component, Input} from '@angular/core';
import {Auction} from "../../../../shared/models/auction.model";
import {AuctionService} from "../../services/auction.service";
import {CreatePayment} from "../../../../shared/models/create-payment";

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.scss']
})
export class CarDetailComponent {
  auction: Auction | undefined;
  private _auctionId: string = '';
  public images = [''];
  public currentImage: number = 0;
  public loggedIn: boolean = false;

  constructor(private auctionService: AuctionService) {
    this.loggedIn = this.localStorage.getItem('token') != null;
  }

  @Input() set auctionId(value: Auction | undefined) {
    if (value !== undefined) {
      this.auction = value;
      this.images = this.auction.car.images.split(',');
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

    this.auctionService.createPayment(payment).subscribe(result => {
      console.log(result);
    });
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

  protected readonly localStorage = localStorage;
}
