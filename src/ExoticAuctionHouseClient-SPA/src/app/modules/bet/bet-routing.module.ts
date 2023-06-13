import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BetContainerComponent } from './container/bet-container/bet-container.component';

const routes: Routes = [
  {
    path: '',
    component: BetContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BetRoutingModule {}
