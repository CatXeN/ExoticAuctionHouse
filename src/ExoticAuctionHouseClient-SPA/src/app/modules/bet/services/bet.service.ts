import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Bet} from "../../../shared/models/bet.model";
import {CreatePayment} from "../../../shared/models/create-payment";

@Injectable({
  providedIn: 'root'
})
export class BetService {
  private baseApiUrl = 'https://localhost:7221/'

  constructor(private httpClient: HttpClient) { }

  getById(id: string): Observable<Bet> {
    return this.httpClient.get<Bet>(this.baseApiUrl + 'api/Bet/' + id);
  }
}
