import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Car} from "../../../shared/models/car.model";

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  private baseUrl: string = 'https://localhost:7218/api/Car'
  constructor(private  httpClient: HttpClient) { }

  public getCars(): Observable<Car[]> {
    return this.httpClient.get<Car[]>(this.baseUrl);
  }
}
