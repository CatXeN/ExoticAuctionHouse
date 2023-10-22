import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UserRegistration} from "../../../shared/models/user-registration.model";
import {Observable} from "rxjs";
import {UserLogin} from "../../../shared/models/user-login.model";
import { apiEndpoints } from 'src/app/core/http/api.endpoints';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private httpClient: HttpClient) { }

  register(data: UserRegistration): Observable<string> {
    return this.httpClient.post<string>(apiEndpoints.auth.register, data);
  }

  login(data: UserLogin): Observable<any> {
    return this.httpClient.post<any>(apiEndpoints.auth.getToken, data);
  }
}
