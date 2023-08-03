import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {
  jwtHelper = new JwtHelperService();
  constructor(public router: Router) {}

  canActivate():
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    console.log('ddaa');
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = this.jwtHelper.decodeToken(token);

      if (Date.now() >= decodedToken.exp * 1000) {
        localStorage.removeItem('token');
        localStorage.removeItem('id');
        this.router.navigate(['']);
        return false;
      }

      return true;
    }

    this.router.navigate(['/auth/login']);
    return false;
  }
}
