import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {SearchModel} from "../../../shared/models/search.model";
import {Auction} from "../../../shared/models/auction.model";
import {CarAttribute} from "../../../shared/models/cat-attribute.model";
import {TrasnlatedAttribute} from "../../../shared/models/translated-attribute.model";

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  private baseUrl: string = 'https://localhost:7218/api/auction/'
  private carUrl: string = 'https://localhost:7218/api/CarAttribute/'

  constructor(private  httpClient: HttpClient) { }

  getCarsByFilter(searchModel: SearchModel): Observable<Auction[]> {
    return this.httpClient.post<Auction[]>(this.baseUrl + 'Search', searchModel);
  }

  getExhibitedCars(): Observable<Auction[]> {
    return this.httpClient.get<Auction[]>(this.baseUrl);
  }

  getAuction(id: string): Observable<Auction> {
    return this.httpClient.get<Auction>(this.baseUrl + id);
  }

  public getAttributes(carId: string): Observable<TrasnlatedAttribute[]> {
    return this.httpClient.get<TrasnlatedAttribute[]>(this.carUrl + 'translated/' + carId);
  }
}
