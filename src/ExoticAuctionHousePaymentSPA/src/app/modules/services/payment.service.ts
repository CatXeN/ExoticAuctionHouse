import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {Payment} from "../../shared/models/payment.model";

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  private basePaymentUrl = 'https://localhost:7260'

  constructor(private httpClient: HttpClient) { }

  getPayment(data: string): Observable<Payment> {
    return this.httpClient.get<Payment>(this.basePaymentUrl + '/Payment/' + data);
  }
}
