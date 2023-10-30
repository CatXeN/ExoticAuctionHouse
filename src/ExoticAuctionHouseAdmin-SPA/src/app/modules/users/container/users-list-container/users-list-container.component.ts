import {Component, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {Car} from "../../../../shared/models/car.model";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {UserService} from "../../services/user.service";
import {User} from "../../../../shared/models/user.model";

@Component({
  selector: 'app-users-list-container',
  templateUrl: './users-list-container.component.html',
  styleUrls: ['./users-list-container.component.scss']
})
export class UsersListContainerComponent {
  displayedColumns: string[] = [ 'id', 'username', 'email', 'attributes', 'role', 'actions' ];
  dataSource: MatTableDataSource<User> = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator: any = MatPaginator;
  @ViewChild(MatSort) sort: any = MatSort;

  constructor(private usersService: UserService) {
    this.usersService.getUsers().subscribe(result => {
      this.dataSource = new MatTableDataSource(result);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
