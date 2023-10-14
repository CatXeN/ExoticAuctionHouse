export interface Auction {
  id: string;
  carId: string;
  createdAt: Date;
  biddingBegins: Date;
  amountStarting: number;
  currentPrice: number;
  location: string;
  isEnd: boolean;
}
