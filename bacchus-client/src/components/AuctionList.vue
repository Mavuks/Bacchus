<template>
    <div class="list row">
        <div class="col-md-5">
            <h4>Auction list</h4>
            <table class="table table-striped border border-dark " >
              <thead class="thead-dark">
                <tr>
                  <th scope="col" >Product Name</th>
                  <th scope="col">Product Description</th>
                  <th scope="col">Product Category</th>
                  <th scope="col">Bidding EndDate</th>
                </tr>
              </thead>
              <tbody v-for="(auction, index) in filteredAuctions" :key="index">
                <td v-if="auction">{{auction.productName}}</td>
                <td v-if="auction"> {{auction.productDescription}}</td>
                <td v-if="auction"> {{auction.productCategory  }}</td>
                <td v-if="auction"> {{auction.biddingEndDate | capitalize}}</td>
                <td v-if="auction">   <router-link :to="{
                            name: 'Bidding',
                            params: {auction: auction}
                        }">Bidding
                        </router-link>
                         </td>

              </tbody>


            </table>

        </div>
        <div class="col-md-6">
            <router-view @refreshData="refreshList"></router-view>
        </div>
    </div>
</template>


<script>
import AuctionDataService from "../services/AuctionDataService";
import moment from 'moment'


export default {
  name: "Auction-List",
  props:{
    category:{
      type: String
    }
  },
  data() {

    return {


      auctions: []
        };
  },
  methods: {

    retrieveAuctionList() {
      AuctionDataService.getAll()
        .then(response => {
          this.auctions = response.data;
          console.log(response.data);
          console.log(this.category)
        })
        .catch(e => {
          console.log(e);
        });
    },
    refreshList() {
      this.retrieveAuctionList();
    },

  },

  mounted() {
    this.retrieveAuctionList();
  },

  computed: {
    filteredAuctions: function(){
      if(this.category == ''){
        return this.auctions.filter((auction) =>{
        return auction.productCategory.match();
      })
      }else{
      return this.auctions.filter((auction) =>{
        return auction.productCategory.match(this.category);
      })
    }
    }
  },
  filters:
  {
    capitalize: function(value){
    if(value){
      return  moment(String(value)).add(-3, 'hours').format('DD.MM.YYYY HH:mm:ss')
    }
  }
  },
};
</script>