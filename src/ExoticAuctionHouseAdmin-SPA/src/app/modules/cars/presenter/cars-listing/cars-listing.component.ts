import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {CarsService} from "../../services/cars.service";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {Car} from "../../../../shared/models/car.model";

@Component({
  selector: 'app-cars-listing',
  templateUrl: './cars-listing.component.html',
  styleUrls: ['./cars-listing.component.scss']
})
export class CarsListingComponent implements AfterViewInit {
  displayedColumns: string[] = [ 'id', 'brand', 'model', 'generation', 'year', 'actions' ];
  dataSource: MatTableDataSource<Car> = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator: any = MatPaginator;
  @ViewChild(MatSort) sort: any = MatSort;

  constructor(private carService: CarsService) {
    this.carService.getCars().subscribe(result => {
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
