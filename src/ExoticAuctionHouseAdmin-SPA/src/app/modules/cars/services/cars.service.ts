import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Car} from "../../../shared/models/car.model";
import {CarPageData} from "../../../shared/models/car-page-data.model";
import {CarAttribute} from "../../../shared/models/car-attribute.model";
import {AddCarAttribute} from "../../../shared/models/add-car-attributes.model";
import { apiEndpoints } from 'src/app/core/http/api.endpoints';

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  constructor(private  httpClient: HttpClient) { }

  public getCars(): Observable<Car[]> {
    return this.httpClient.get<Car[]>(apiEndpoints.cars.carController);
  }

  public getCar(id: string): Observable<Car> {
    return this.httpClient.get<Car>(apiEndpoints.cars.carController + id);
  }

  getPageData(): Observable<CarPageData> {
    return this.httpClient.get<CarPageData>(apiEndpoints.cars.pageData)
  }

  public addCar(car: Car): Observable<string> {
    return this.httpClient.post<string>(apiEndpoints.cars.carController, car);
  }

  public editCar(car: Car): Observable<Car> {
    return this.httpClient.put<Car>(apiEndpoints.cars.carController, car);
  }

  public getAttributes(carId: string): Observable<CarAttribute[]> {
    return this.httpClient.get<CarAttribute[]>(apiEndpoints.carAttributes.carAttributeController + carId);
  }

  public addAttributes(carAttribute: AddCarAttribute): Observable<string> {
    return this.httpClient.post<string>(apiEndpoints.carAttributes.carAttributeController, carAttribute);
  }

  public updateImage(formData: FormData, carId: string): Observable<boolean> {
    return this.httpClient.post<boolean>(apiEndpoints.cars.uploadImages + carId, formData);
  }

  public getAvailableCars(): Observable<Car[]> {
    return this.httpClient.get<Car[]>(apiEndpoints.cars.availableCars);
  }
}
