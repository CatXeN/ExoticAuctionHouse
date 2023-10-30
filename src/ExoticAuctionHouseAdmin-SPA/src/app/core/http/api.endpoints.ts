import { environment } from '../../../environments/environment';

export const apiEndpoints = {
  auth: {
    loginAsAdmin: `${environment.authApiUrl}/api/auth/loginAsAdmin`
  },
  cars: {
    carController: `${environment.apiUrl}/api/car/`,
    pageData: `${environment.apiUrl}/api/car/pageData`,
    uploadImages: `${environment.apiUrl}/api/car/uploadImages/`
  },
  carAttributes: {
    carAttributeController: `${environment.apiUrl}/api/CarAttribute/`
  },
  auctions: {
    getAuction: `${environment.apiUrl}/api/auction`,
    getAuctions: `${environment.apiUrl}/api/auction/allAuctions`,
    getAuctionById: `${environment.apiUrl}/api/auction/`,
    addOrUpdate: `${environment.apiUrl}/api/auction/`
  },
  attributes: {
    getAttributes: `${environment.apiUrl}/api/attribute/`
  },
  users: {
    getUsers: `${environment.authApiUrl}/api/users/`
  }
}
