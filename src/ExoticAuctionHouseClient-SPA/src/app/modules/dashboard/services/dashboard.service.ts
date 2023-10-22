import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarPageData } from 'src/app/shared/models/car-page-data.model';
import {environment} from "../../../../environments/environment";
import { apiEndpoints } from 'src/app/core/http/api.endpoints';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  constructor(private httpClient: HttpClient) { }

  getPageData(): Observable<CarPageData> {
    return this.httpClient.get<CarPageData>(apiEndpoints.cars.pageData)
  }

  getModelsByBrand(brand: string): Observable<string[]> {
    return this.httpClient.get<string[]>(apiEndpoints.cars.getModels + brand);
  }
}
