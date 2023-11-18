import {Car} from "./car.model";

export interface MyAuctions {
  id: string;
  carId: string;
  car: Car;
  soldAt: Date;
  price: number;
  isSold: boolean;
  userId: string;
}
