import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {UsersListContainerComponent} from "./container/users-list-container/users-list-container.component";

const routes: Routes = [
  {
    path: '',
    component: UsersListContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule {}
