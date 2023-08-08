import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CarsListContainerComponent} from "./container/cars-list-container/cars-list-container.component";
import {CarsEditContainerComponent} from "./container/cars-edit-container/cars-edit-container.component";

const routes: Routes = [
  {
    path: '',
    component: CarsListContainerComponent
  },
  {
    path: 'edit/:id',
    component: CarsEditContainerComponent
  },
  {
    path: 'edit',
    component: CarsEditContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarsRoutingModule {}
