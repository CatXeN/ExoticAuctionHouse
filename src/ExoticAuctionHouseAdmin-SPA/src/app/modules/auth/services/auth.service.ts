import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Login} from "../../../shared/models/login.model";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl: string = 'https://localhost:7250/api/auth/'
  constructor(private httpClient: HttpClient) { }

  loginAsAdmin(data: Login): Observable<string> {
    return this.httpClient.post<string>(this.baseUrl + 'loginAsAdmin', data);
  }
}
