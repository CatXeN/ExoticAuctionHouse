import { Component, ViewChild } from '@angular/core';
import { AuctionsService } from '../../services/auctions.service';
import { MatTab } from '@angular/material/tabs';
import { MatTableDataSource } from '@angular/material/table';
import { Auction } from 'src/app/shared/models/auction.model';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-auctions-listing',
  templateUrl: './auctions-listing.component.html',
  styleUrls: ['./auctions-listing.component.scss']
})
export class AuctionsListingComponent {
  displayedColumns: string[] = [ 'id', 'Starting amount', 'Current Price', 'Start date', 'Creation date', 'Car id', 'Location', 'isEnd' ];
  dataSource: MatTableDataSource<Auction> = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator: any = MatPaginator;
  @ViewChild(MatTab) sort: any = MatTab;

  constructor(private auctionService: AuctionsService) {
    this.auctionService.getAllAuctions().subscribe(result => {
      this.dataSource = new MatTableDataSource(result);
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
