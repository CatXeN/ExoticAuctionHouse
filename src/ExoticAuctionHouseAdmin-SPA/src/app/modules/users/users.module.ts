import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersListContainerComponent } from './container/users-list-container/users-list-container.component';
import {UsersRoutingModule} from "./users-routing.module";

@NgModule({
  imports: [
    CommonModule,
    UsersRoutingModule,
    SharedModule
  ],
  declarations: [
    UsersListContainerComponent
  ]
})
export class UsersModule { }
