import {Component, OnInit} from '@angular/core';
import {PaymentService} from "../services/payment.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Payment} from "../../shared/models/payment.model";

@Component({
  selector: 'app-choose-payment',
  templateUrl: './choose-payment.component.html',
  styleUrls: ['./choose-payment.component.scss']
})
export class ChoosePaymentComponent implements OnInit {
  public selectedPayment: number = 0;
  private payment: Payment | null = null

  constructor(private paymentService: PaymentService, private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe(params => {
      if (params['id'] !== undefined) {
        this.paymentService.getPayment(params['id']).subscribe(res => {
          this.payment = res;
        })
      } else {
        this.router.navigate(['']);
      }
    });
  }

  public selectedEvent(event: number): void {
    this.selectedPayment = event;
  }

  public pay(): void {
    this.router.navigate(['/pay'], { state: { data: this.payment }})
  }

  ngOnInit(): void {
  }
}
