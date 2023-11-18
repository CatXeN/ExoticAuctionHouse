export interface Payment {
  id: string;
  paymentStatus: number;
  amount: number;
  createdAt: Date;
  lastModify: Date;
  clientId: string;
  ticketId: string;
}
