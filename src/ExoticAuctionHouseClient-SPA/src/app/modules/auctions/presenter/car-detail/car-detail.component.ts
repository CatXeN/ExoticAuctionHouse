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
  public images = ['https://autogen.pl/cars/_mini/Por992TurboS-850x430.jpg', 'https://di-uploads-pod15.dealerinspire.com/porschewestpalmbeach/uploads/2020/03/2020-porsche-911-carrera-s.jpg', 'https://www.cnet.com/a/img/resize/5d412b9c47c52d6047d4cf0aa138cb666063d0a3/hub/2020/07/01/f9fd026c-cf70-4170-a1c6-53521c35a21a/2020-porsche-911-carrera-s-manual-001.jpg?auto=webp&fit=crop&height=675&width=1200']
  public currentImage: number = 0;

  constructor(private auctionService: AuctionService) {}

  @Input() set auctionId(value: Auction | undefined) {
    if (value !== undefined) {
      this.auction = value;
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
}
