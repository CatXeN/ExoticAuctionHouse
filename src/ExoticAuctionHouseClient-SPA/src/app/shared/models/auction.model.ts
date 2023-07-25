import {Car} from "./car.model";

export interface Auction {
  id: string;
  carId: string;
  car: Car;
  createdAt: Date;
  biddingBegins: Date;
  amountStarting: number;
}
