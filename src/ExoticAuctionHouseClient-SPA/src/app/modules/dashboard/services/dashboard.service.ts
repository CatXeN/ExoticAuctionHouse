import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarPageData } from 'src/app/shared/models/car-page-data.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  baseUrl: string = 'https://localhost:7218/api/car/'

  constructor(private httpClient: HttpClient) { }

  getPageData(): Observable<CarPageData> {
    return this.httpClient.get<CarPageData>(this.baseUrl + 'PageData')
  }

  getModelsByBrand(brand: string): Observable<string[]> {
    return this.httpClient.get<string[]>(this.baseUrl + 'GetModels/' + brand);
  }
}
