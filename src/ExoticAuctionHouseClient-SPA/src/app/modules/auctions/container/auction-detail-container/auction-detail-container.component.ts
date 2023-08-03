import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, ParamMap} from "@angular/router";
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-auction-detail-container',
  templateUrl: './auction-detail-container.component.html',
  styleUrls: ['./auction-detail-container.component.scss']
})
export class AuctionDetailContainerComponent implements OnInit{
  auctionId: string = '';

  constructor(private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.auctionId = params.get('id') || '';
    })
  }
}
