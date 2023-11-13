import { Component } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Payment} from "../../shared/models/payment.model";
import {Pay} from "../../shared/models/pay.model";
import {PaymentService} from "../services/payment.service";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-pay-view',
  templateUrl: './pay-view.component.html',
  styleUrls: ['./pay-view.component.scss']
})
export class PayViewComponent {
  public payment: Payment | null = null;

  constructor(private route: ActivatedRoute, private  paymentService: PaymentService) {
    this.payment = history.state.data;
  }

  public pay(): void {
    if (this.payment === null)
      return;

    //in the future should redirect to user panel
    let payInfo: Pay = {
      id: this.payment.id,
      clientId: this.payment.clientId
    }

    this.paymentService.pay(payInfo).subscribe(res => {
      console.log('Payment end');
      location.href = environment.production ? 'http://exoticah.pl/panel/auctions' : 'http://localhost:4201/panel/auctions';
    })
  }

  public cancel(): void {
    location.href = environment.production ?
      'https://exoticah.pl/panel/auctions/' + this.payment?.ticketId : 'http://localhost:4201/panel/auctions/' + this.payment?.ticketId;
  }
}
