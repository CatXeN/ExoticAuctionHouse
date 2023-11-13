import { environment } from "src/environments/environment";

export const apiEndpoints = {
  payments: {
    getPayment: `${environment.paymentApiUrl}/payment/`,
    pay: `${environment.paymentApiUrl}/payment/pay`
  }
}
