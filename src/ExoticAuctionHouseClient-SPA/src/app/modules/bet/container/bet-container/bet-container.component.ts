import {Component, OnInit} from '@angular/core';
import * as signalR from "@microsoft/signalr";
import {HubConnection} from "@microsoft/signalr";
import {ActivatedRoute, ParamMap} from "@angular/router";

@Component({
  selector: 'app-bet-container',
  templateUrl: './bet-container.component.html',
  styleUrls: ['./bet-container.component.scss']
})
export class BetContainerComponent implements OnInit {
  connection: HubConnection | undefined;
  userId: string | null = null;
  auctionId: string = '';
  currentPrice: number = 0;

  constructor(private route: ActivatedRoute) {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.auctionId = params.get('id') || '';
    })
  }

  ngOnInit(): void {
    this.userId = localStorage.getItem('id');
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:7221/Auction", {
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    this.connection.start().then(() => {
      console.log('connected');
    }).catch(err => console.log(err));

    this.connection.on("ReceiveMessage", (user, message) => {
      console.log("User: " + user + " Bid: " + message);
    });
  }

  sendMessage(): void {
    this.connection?.invoke("SendMessage", this.userId, this.auctionId, '10');
  }
}
