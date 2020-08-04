import http from "../http-common";

class AuctionDataService {
  getAll() {
    return http.get("api/auction");
  }
  postBidding(data){
    return http.post(`api/Biddings`, data);
  }







}

export default new AuctionDataService();