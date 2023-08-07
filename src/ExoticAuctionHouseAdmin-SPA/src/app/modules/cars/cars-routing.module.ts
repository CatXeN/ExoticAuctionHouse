import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CarsListContainerComponent} from "./container/cars-list-container/cars-list-container.component";

const routes: Routes = [
  {
    path: '',
    component: CarsListContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarsRoutingModule {}
