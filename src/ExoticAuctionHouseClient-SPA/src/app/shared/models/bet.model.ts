export interface Bet {
    id: string;
    auctionId: string;
    carId: string;
    currentPrice: number;
    lastUserId: string;
    lastTime: Date;
}
