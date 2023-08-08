import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Car} from "../../../shared/models/car.model";
import {CarPageData} from "../../../shared/models/car-page-data.model";

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  private baseUrl: string = 'https://localhost:7218/api/Car'
  constructor(private  httpClient: HttpClient) { }

  public getCars(): Observable<Car[]> {
    return this.httpClient.get<Car[]>(this.baseUrl);
  }

  public getCar(id: string): Observable<Car> {
    return this.httpClient.get<Car>(this.baseUrl + '/' + id);
  }

  getPageData(): Observable<CarPageData> {
    return this.httpClient.get<CarPageData>(this.baseUrl + '/PageData')
  }
}
