import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {CarPageData} from "../../../shared/models/car-page-data.model";
import {SearchModel} from "../../../shared/models/search.model";
import {Car} from "../../../shared/models/car.model";
import {Auction} from "../../../shared/models/auction.model";

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  private baseUrl: string = 'https://localhost:7218/api/auction/'
  constructor(private  httpClient: HttpClient) { }

  getCarsByFilter(searchModel: SearchModel): Observable<Auction[]> {
    return this.httpClient.post<Auction[]>(this.baseUrl + 'Search', searchModel);
  }

  getExhabitedCars(): Observable<Auction[]> {
    return this.httpClient.get<Auction[]>(this.baseUrl);
  }

  getAuction(id: string): Observable<Auction> {
    return this.httpClient.get<Auction>(this.baseUrl + id);
  }
}
