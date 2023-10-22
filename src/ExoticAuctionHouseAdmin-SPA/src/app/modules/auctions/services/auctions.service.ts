import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiEndpoints } from 'src/app/core/http/api.endpoints';
import { Auction } from 'src/app/shared/models/auction.model';

@Injectable({
  providedIn: 'root',
})
export class AuctionsService {
  constructor(private httpClient: HttpClient) {}

  public getAuctions(): Observable<Auction[]> {
    return this.httpClient.get<Auction[]>(apiEndpoints.auctions.getAuction);
  }

  public getAllAuctions(): Observable<Auction[]> {
    return this.httpClient.get<Auction[]>(apiEndpoints.auctions.getAuctions);
  }

  public getAuction(id: string): Observable<Auction> {
    return this.httpClient.get<Auction>(apiEndpoints.auctions.getAuctionById + id);
  }

  public addAuction(auction: Auction): Observable<string> {
    return this.httpClient.post<string>(apiEndpoints.auctions.addOrUpdate, auction);
  }

  public editAuction(auction: Auction): Observable<Auction> {
    return this.httpClient.put<Auction>(apiEndpoints.auctions.addOrUpdate, auction);
  }
}
