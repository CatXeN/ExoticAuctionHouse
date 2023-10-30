import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Car} from "../../../shared/models/car.model";
import {apiEndpoints} from "../../../core/http/api.endpoints";
import {User} from "../../../shared/models/user.model";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private  httpClient: HttpClient) { }

  public getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(apiEndpoints.users.getUsers);
  }
}
