import {Car} from "./car.model";
import {Auction} from "./auction.model";
import {AddCarAttribute} from "./add-car-attributes.model";

export interface SellCar {
  car: Car;
  auction: Auction;
  addCarAttributeInformation: AddCarAttribute
}
