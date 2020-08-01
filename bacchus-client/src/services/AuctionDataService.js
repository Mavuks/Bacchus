import http from "../http-common";

class AuctionDataService {
  getAll() {
    return http.get("api/auction");
  }
  postBidding(data){
    return http.post(`Biddings`, data);
  }







}

export default new AuctionDataService();