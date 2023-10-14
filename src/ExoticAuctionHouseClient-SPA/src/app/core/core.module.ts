import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MobileMenuComponent } from './mobile-menu/mobile-menu.component';
import { MobileMenuListComponent } from './mobile-menu-list/mobile-menu-list.component';

@NgModule({
  declarations: [
    MobileMenuComponent,
    MobileMenuListComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    HttpClientModule,
    SharedModule
  ],
  exports: [
    MobileMenuComponent,
    MobileMenuListComponent
  ]
})
export class CoreModule { }
