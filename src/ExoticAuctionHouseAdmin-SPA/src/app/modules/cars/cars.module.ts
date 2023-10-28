import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CarsListContainerComponent} from "./container/cars-list-container/cars-list-container.component";
import {CarsRoutingModule} from "./cars-routing.module";
import { CarsListingComponent } from './presenter/cars-listing/cars-listing.component';
import { CarsEditContainerComponent } from './container/cars-edit-container/cars-edit-container.component';
import { CarDetailsComponent } from './presenter/car-details/car-details.component';
import { CarAttributesComponent } from './presenter/car-attributes/car-attributes.component';
import { CarImageComponent } from './presenter/car-image/car-image.component';

@NgModule({
  imports: [
    CommonModule,
    CarsRoutingModule,
    SharedModule
  ],
  declarations: [
    CarsListContainerComponent,
    CarsListingComponent,
    CarsEditContainerComponent,
    CarDetailsComponent,
    CarAttributesComponent,
    CarImageComponent
  ]
})
export class CarsModule { }
