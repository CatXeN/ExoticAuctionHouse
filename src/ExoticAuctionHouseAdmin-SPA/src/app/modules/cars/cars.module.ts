import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CarsListContainerComponent} from "./container/cars-list-container/cars-list-container.component";
import {CarsRoutingModule} from "./cars-routing.module";
import { CarsListingComponent } from './presenter/cars-listing/cars-listing.component';

@NgModule({
  imports: [
    CommonModule,
    CarsRoutingModule,
    SharedModule
  ],
  declarations: [
    CarsListContainerComponent,
    CarsListingComponent
  ]
})
export class CarsModule { }
