import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Login} from "../../../shared/models/login.model";
import { apiEndpoints } from 'src/app/core/http/api.endpoints';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private httpClient: HttpClient) { }

  loginAsAdmin(data: Login): Observable<string> {
    return this.httpClient.post<string>(apiEndpoints.auth.loginAsAdmin, data);
  }
}
