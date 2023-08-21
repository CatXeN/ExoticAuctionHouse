export interface Auction {
  id: string;
  startingAmount: number;
  startDate: Date;
  carId: string;
  creationDate: Date;
  currentPrice: number;
  location: string;
  isEnd: boolean;
}
