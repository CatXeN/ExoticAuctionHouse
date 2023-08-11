import {Attribute, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AttributeService {
  baseUrl: string = 'https://localhost:7218/api/Attribute';
  constructor(private _httpClient: HttpClient) { }

  public getAttributes(): Observable<Attribute[]> {
    return this._httpClient.get<Attribute[]>(this.baseUrl);
  }
}
