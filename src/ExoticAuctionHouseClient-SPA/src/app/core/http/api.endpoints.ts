import { environment } from '../../../environments/environment';

export const apiEndpoints = {
  auction: {
    getCarsByFilter: `${environment.apiUrl}/api/auction/search`,
    getExhibitedCars: `${environment.apiUrl}/api/auction/`,
    getAuction: `${environment.apiUrl}/api/auction/`
  },
  auctionHistory: {
    getMyAuctions: `${environment.apiUrl}/api/auctionHistory/myAuctions/`
  },
  carAttributes: {
    getAttributes: `${environment.apiUrl}/api/CarAttribute/translated/`
  },
  payments: {
    createPayment: `${environment.paymentApiUrl}/payment`,
    getClientPayments: `${environment.paymentApiUrl}/payment/getClientPayments/`
  },
  auth: {
    register: `${environment.authApiUrl}/api/auth/register`,
    getToken: `${environment.authApiUrl}/api/auth/login`
  },
  cars: {
    pageData: `${environment.apiUrl}/api/car/pageData`,
    getModels: `${environment.apiUrl}/api/car/getModels/`
  },
  bet: {
    getBetById: `${environment.auctionServer}/api/bet/`
  }
}
