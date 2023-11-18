import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MyAuctions} from "../../../shared/models/my-auctions.model";
import {apiEndpoints} from "../../../core/http/api.endpoints";
import {Payment} from "../../../shared/models/payment.model";
import {Attribute} from "../../../shared/models/attribute.model";
import {SellCar} from "../../../shared/models/sell-car.model";
import {CommonInformation} from "../../../shared/models/common-information.model";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private userId: string | null = localStorage.getItem('id');

  constructor(private _httpClient: HttpClient) { }

  public getMyAuctions(): Observable<MyAuctions[]> {
    return this._httpClient.get<MyAuctions[]>(apiEndpoints.auctionHistory.getMyAuctions + this.userId);
  }

  public getClientPayments(): Observable<Payment[]> {
    return this._httpClient.get<Payment[]>(apiEndpoints.payments.getClientPayments + this.userId);
  }

  public getAttributes(): Observable<Attribute[]> {
    return this._httpClient.get<Attribute[]>(apiEndpoints.attributes.getAttributes);
  }

  public updateImage(formData: FormData, carId: string): Observable<boolean> {
    return this._httpClient.post<boolean>(apiEndpoints.cars.uploadImages + carId, formData);
  }

  public sellCar(data: SellCar): Observable<CommonInformation> {
    return this._httpClient.post<CommonInformation>(apiEndpoints.cars.sellCar, data);
  }
}
