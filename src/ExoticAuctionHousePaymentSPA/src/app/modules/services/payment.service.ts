import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {Payment} from "../../shared/models/payment.model";
import { apiEndpoints } from 'src/app/shared/api.endpoints';
import {Pay} from "../../shared/models/pay.model";

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  constructor(private httpClient: HttpClient) { }

  getPayment(data: string): Observable<Payment> {
    return this.httpClient.get<Payment>(apiEndpoints.payments.getPayment + data);
  }

  pay(data: Pay): Observable<string> {
    return this.httpClient.post<string>(apiEndpoints.payments.pay, data);
  }
}
