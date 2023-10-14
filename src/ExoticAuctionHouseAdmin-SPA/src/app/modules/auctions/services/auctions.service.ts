import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Auction } from 'src/app/shared/models/auction.model';

@Injectable({
  providedIn: 'root'
})
export class AuctionsService {

  private baseUrl: string = 'https://localhost:7218/api/Auction'

  constructor(private  httpClient: HttpClient) {}

    public getAuctions(): Observable<Auction[]> {
      return this.httpClient.get<Auction[]>(this.baseUrl);
    }

    public getAllAuctions(): Observable<Auction[]> {
      return this.httpClient.get<Auction[]>(this.baseUrl + '/allAuctions');
    }

    public getAuction(id: string): Observable<Auction> {
      return this.httpClient.get<Auction>(this.baseUrl + '/' + id);
    }

    public addAuction(auction: Auction): Observable<string> {
      return this.httpClient.post<string>(this.baseUrl, auction);
    }

    public editAuction(auction: Auction): Observable<Auction> {
      return this.httpClient.put<Auction>(this.baseUrl, auction);
    }


}
