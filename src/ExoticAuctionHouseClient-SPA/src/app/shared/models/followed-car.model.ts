import {Car} from "./car.model";

export interface FollowedCar {
   id: string;
   carId: string;
   clientId: string;
   car: Car;
}
