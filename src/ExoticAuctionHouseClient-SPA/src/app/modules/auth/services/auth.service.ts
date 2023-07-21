import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UserRegistration} from "../../../shared/models/user-registration.model";
import {Observable} from "rxjs";
import {UserLogin} from "../../../shared/models/user-login.model";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl: string = 'https://localhost:7250/api/auth/'
  constructor(private httpClient: HttpClient) { }

  register(data: UserRegistration): Observable<string> {
    return this.httpClient.post<string>(this.baseUrl + 'register', data);
  }

  login(data: UserLogin): Observable<any> {
    return this.httpClient.post<any>(this.baseUrl + 'login', data);
  }
}
