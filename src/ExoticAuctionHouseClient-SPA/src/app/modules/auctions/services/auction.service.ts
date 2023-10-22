import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {SearchModel} from "../../../shared/models/search.model";
import {Auction} from "../../../shared/models/auction.model";
import {CarAttribute} from "../../../shared/models/cat-attribute.model";
import {TrasnlatedAttribute} from "../../../shared/models/translated-attribute.model";
import {CreatePayment} from "../../../shared/models/create-payment";
import { environment } from '../../../../environments/environment';
import { apiEndpoints } from 'src/app/core/http/api.endpoints';

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  private basePaymentUrl = 'https://localhost:7260'

  constructor(private  httpClient: HttpClient) { }

  getCarsByFilter(searchModel: SearchModel): Observable<Auction[]> {
    return this.httpClient.post<Auction[]>(apiEndpoints.auction.getCarsByFilter, searchModel);
  }

  getExhibitedCars(): Observable<Auction[]> {
    return this.httpClient.get<Auction[]>(apiEndpoints.auction.getExhibitedCars);
  }

  getAuction(id: string): Observable<Auction> {
    return this.httpClient.get<Auction>(apiEndpoints.auction.getAuction + id);
  }

  public getAttributes(carId: string): Observable<TrasnlatedAttribute[]> {
    return this.httpClient.get<TrasnlatedAttribute[]>(apiEndpoints.carAttributes.getAttributes + carId);
  }

  createPayment(data: CreatePayment): Observable<any> {
    return this.httpClient.post<any>(apiEndpoints.payments.createPayment, data);
  }
}
