import {Car} from "./car.model";

export class Auction {
  id!: string;
  carId!: string;
  car!: Car;
  createdAt!: Date;
  biddingBegins!: Date;
  amountStarting!: number;
  currentPrice!: number;
  location!: string;
  isEnd!: boolean;
}
