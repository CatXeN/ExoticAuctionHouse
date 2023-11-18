import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MainPanelContainerComponent} from "./container/main-panel-container/main-panel-container.component";

const routes: Routes = [
  {
    path: '',
    component: MainPanelContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserPanelRoutingModule {}
