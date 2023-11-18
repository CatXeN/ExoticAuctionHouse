import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {UserService} from "../../services/user.service";
import {Payment} from "../../../../shared/models/payment.model";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-my-payments-presenter',
  templateUrl: './my-payments-presenter.component.html',
  styleUrls: ['./my-payments-presenter.component.scss']
})
export class MyPaymentsPresenterComponent implements OnInit {
  displayedColumns: string[] = ['id', 'amount', 'createdAt', 'lastModify', 'status'];
  dataSource = new MatTableDataSource<Payment>();
  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;

  constructor(private userService: UserService) {
  }

  public ngOnInit(): void {
    this.userService.getClientPayments().subscribe(res => {
      this.dataSource = new MatTableDataSource<Payment>(res);
      this.dataSource.paginator = this.paginator!;
    })
  }
}
