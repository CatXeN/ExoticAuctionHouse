import { Component } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Payment} from "../../shared/models/payment.model";

@Component({
  selector: 'app-pay-view',
  templateUrl: './pay-view.component.html',
  styleUrls: ['./pay-view.component.scss']
})
export class PayViewComponent {
  public payment: Payment | null = null;

  constructor(private route: ActivatedRoute) {
    this.payment = history.state.data;
    console.log(history.state);
  }

  cancel(): void {
    location.href = 'http://localhost:4201';
  }
}
