import { environment } from '../../../environments/environment';

export const apiEndpoints = {
  auction: {
    getCarsByFilter: `${environment.apiUrl}/api/auction/search`,
    getExhibitedCars: `${environment.apiUrl}/api/auction/`,
    getAuction: `${environment.apiUrl}/api/auction/`,
    getAuctionByCar: `${environment.apiUrl}/api/auction/GetAuctionId/`
  },
  attributes: {
    getAttributes: `${environment.apiUrl}/api/attribute/`
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
    getToken: `${environment.authApiUrl}/api/auth/login`,
    getUsers: `${environment.authApiUrl}/api/Users`
  },
  cars: {
    pageData: `${environment.apiUrl}/api/car/pageData`,
    getModels: `${environment.apiUrl}/api/car/getModels/`,
    carController: `${environment.apiUrl}/api/car/`,
    sellCar: `${environment.apiUrl}/api/car/sellCar`,
    uploadImages: `${environment.apiUrl}/api/car/uploadImages/`,
    setFavorite: `${environment.apiUrl}/api/car/followingCar`,
    getFavorite: `${environment.apiUrl}/api/car/clientFollowingCar/`,
    getFollowedCars: `${environment.apiUrl}/api/car/getFollowedCars/`
  },
  bet: {
    getBetById: `${environment.auctionServer}/api/bet/`
  }
}
