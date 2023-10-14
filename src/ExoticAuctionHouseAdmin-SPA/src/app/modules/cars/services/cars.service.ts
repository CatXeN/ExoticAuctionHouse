import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Car} from "../../../shared/models/car.model";
import {CarPageData} from "../../../shared/models/car-page-data.model";
import {CarAttribute} from "../../../shared/models/car-attribute.model";
import {AddCarAttribute} from "../../../shared/models/add-car-attributes.model";

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  private baseUrl: string = 'https://localhost:7218/api/Car'
  private urlAttributes: string = 'https://localhost:7218/api/CarAttribute'

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

  public addCar(car: Car): Observable<string> {
    return this.httpClient.post<string>(this.baseUrl, car);
  }

  public editCar(car: Car): Observable<Car> {
    return this.httpClient.put<Car>(this.baseUrl, car);
  }

  public getAttributes(carId: string): Observable<CarAttribute[]> {
    return this.httpClient.get<CarAttribute[]>(this.urlAttributes  + '/' + carId);
  }

  public addAttributes(carAttribute: AddCarAttribute): Observable<string> {
    return this.httpClient.post<string>(this.urlAttributes, carAttribute);
  }
}
