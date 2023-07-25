import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {CarPageData} from "../../../shared/models/car-page-data.model";
import {SearchModel} from "../../../shared/models/search.model";
import {Car} from "../../../shared/models/car.model";

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  private baseUrl: string = 'https://localhost:7218/api/car/'
  constructor(private  httpClient: HttpClient) { }

  getCarsByFilter(searchModel: SearchModel): Observable<Car[]> {
    return this.httpClient.get<Car[]>(this.baseUrl + 'Search', {params: searchModel as any});
  }
}
