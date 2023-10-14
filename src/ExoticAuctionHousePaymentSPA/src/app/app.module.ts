import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ChoosePaymentComponent } from './modules/choose-payment/choose-payment.component';
import {MaterialModule} from "./shared/material";
import { ErrorPageComponent } from './modules/error-page/error-page.component';
import {HttpClientModule} from "@angular/common/http";
import { PayViewComponent } from './modules/pay-view/pay-view.component';

@NgModule({
  declarations: [
    AppComponent,
    ChoosePaymentComponent,
    ErrorPageComponent,
    PayViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
