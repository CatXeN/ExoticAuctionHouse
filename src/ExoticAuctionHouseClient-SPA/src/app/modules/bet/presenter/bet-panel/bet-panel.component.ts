import {Component, Input, OnInit} from '@angular/core';
import {HubConnection} from "@microsoft/signalr";
import {ActivatedRoute, ParamMap} from "@angular/router";
import * as signalR from "@microsoft/signalr";
import {Auction} from "../../../../shared/models/auction.model";
import {inputNames} from "@angular/cdk/schematics";
import {BetService} from "../../services/bet.service";
import {environment} from "../../../../../environments/environment";
import { User } from 'src/app/shared/models/user.model';

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
  public remainingTime: number = 120;
  private interval: any;
  public userListBet: any = [];
  public users: User[] = [];

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
    this.betService.getUsers().subscribe(res => {
      this.users = res;
    })

    this.userId = localStorage.getItem('id');
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.auctionServer + "/Auction", {
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    this.connection.start().then(() => {
      console.log('connected');
    }).catch(err => console.log(err));

    this.connection.on("ReceiveMessage", (user, message) => {
      console.log("User: " + user + " Bid: " + message);

      this.userListBet.push({user: user, amount: message});

      if (!this.interval) {
        this.interval = setInterval(() => {
          if(this.remainingTime > 0) {
            this.remainingTime--;
          }
        },1000)
      }

      this.currentPrice = Number(message);
    });

    if (this.auction) {
      this.currentPrice = this.auction.currentPrice;
    }
  }

  sendMessage(): void {
    this.remainingTime = 120;
    const offer: number = this.currentPrice + 1000;
    console.log(this.auction?.id);

    this.connection?.invoke("SendMessage", this.userId, this.auction?.id, offer);
  }

  public getUserName(guid: string) {
    return this.users.find(x => x.id == guid)?.username;
  }
}
