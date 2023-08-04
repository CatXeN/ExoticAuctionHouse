import {Component, Input, OnInit} from '@angular/core';
import {HubConnection} from "@microsoft/signalr";
import {ActivatedRoute, ParamMap} from "@angular/router";
import * as signalR from "@microsoft/signalr";
import {Auction} from "../../../../shared/models/auction.model";
import {inputNames} from "@angular/cdk/schematics";
import {BetService} from "../../services/bet.service";

@Component({
  selector: 'app-bet-panel',
  templateUrl: './bet-panel.component.html',
  styleUrls: ['./bet-panel.component.scss']
})
export class BetPanelComponent implements OnInit {
  connection: HubConnection | undefined;
  userId: string | null = null;
  currentPrice: number = 0;
  auction: Auction | null = null;


  @Input() set auctionInput(value: Auction | null) {
    if (value !== undefined && value !== null) {
      this.auction = value;

      this.betService.getById(this.auction.id).subscribe(result => {
        this.currentPrice = result.currentPrice;
      });
    }
  }

  constructor(private betService: BetService) {}

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
      this.currentPrice = Number(message);
    });

    if (this.auction) {
      this.currentPrice = this.auction.currentPrice;
    }
  }

  sendMessage(): void {
    const offer: number = this.currentPrice + 1000;
    console.log(this.auction?.id);

    this.connection?.invoke("SendMessage", this.userId, this.auction?.id, offer);
  }
}
