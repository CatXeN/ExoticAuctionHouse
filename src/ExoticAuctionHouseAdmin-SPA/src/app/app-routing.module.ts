import { AuthLayoutComponent } from './core/layouts/auth-layout/auth-layout.component';
import { LoginContainerComponent } from './modules/auth/container/login-container/login-container.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './core/layouts/main-layout/main-layout.component';
import {AuthGuard} from "./modules/auth/guard/auth.guard";

const routes: Routes = [
  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)
      },
    ]
  },
  {
    path: 'panel',
    component: MainLayoutComponent,
    children: [
      {
        path: 'dashboard',
        loadChildren: () => import('./modules/dashboard/dashboard.module').then(m => m.DashboardModule),
        canActivate: [AuthGuard]
      },
      {
        path: 'cars',
        loadChildren: () => import('./modules/cars/cars.module').then(m => m.CarsModule),
        canActivate: [AuthGuard]
      },
      {
        path: 'auctions',
        loadChildren: () => import('./modules/auctions/auctions.module').then(m => m.AuctionsModule),
        canActivate: [AuthGuard]
      },
      {
        path: 'users',
        loadChildren: () => import('./modules/users/users.module').then(m => m.UsersModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
