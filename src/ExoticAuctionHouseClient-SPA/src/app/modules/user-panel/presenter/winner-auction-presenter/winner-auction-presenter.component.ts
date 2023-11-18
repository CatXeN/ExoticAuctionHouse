import {Component, OnInit} from '@angular/core';
import {UserService} from "../../services/user.service";
import {MyAuctions} from "../../../../shared/models/my-auctions.model";

@Component({
  selector: 'app-winner-auction-presenter',
  templateUrl: './winner-auction-presenter.component.html',
  styleUrls: ['./winner-auction-presenter.component.scss']
})
export class WinnerAuctionPresenterComponent implements OnInit {
  public myAuctions: MyAuctions[] = [];

  constructor(private userService: UserService) {
  }

  public ngOnInit(): void {
    this.userService.getMyAuctions().subscribe(res => {
      this.myAuctions = res;
    })
  }
}
