import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Bet} from "../../../shared/models/bet.model";
import {CreatePayment} from "../../../shared/models/create-payment";
import { apiEndpoints } from 'src/app/core/http/api.endpoints';
import { User } from 'src/app/shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class BetService {
  constructor(private httpClient: HttpClient) { }

  getById(id: string): Observable<Bet> {
    return this.httpClient.get<Bet>(apiEndpoints.bet.getBetById + id);
  }

  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(apiEndpoints.auth.getUsers);
  }
}
