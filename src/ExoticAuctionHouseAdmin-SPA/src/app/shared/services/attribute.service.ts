import {Attribute, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { apiEndpoints } from 'src/app/core/http/api.endpoints';

@Injectable({
  providedIn: 'root'
})
export class AttributeService {
  constructor(private _httpClient: HttpClient) { }

  public getAttributes(): Observable<Attribute[]> {
    return this._httpClient.get<Attribute[]>(apiEndpoints.attributes.getAttributes);
  }
}
