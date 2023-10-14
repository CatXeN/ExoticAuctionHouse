import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ChoosePaymentComponent} from "./modules/choose-payment/choose-payment.component";
import {ErrorPageComponent} from "./modules/error-page/error-page.component";
import {PayViewComponent} from "./modules/pay-view/pay-view.component";

const routes: Routes = [
  {
    path: '',
    component: ErrorPageComponent
  },
  {
    path: 'method/:id',
    component: ChoosePaymentComponent
  },
  {
    path: 'pay',
    component: PayViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
