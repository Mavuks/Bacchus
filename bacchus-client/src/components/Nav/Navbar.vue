<template>
  <div>
    <b-button v-b-toggle.sidebar-1>Menu</b-button>
    <b-sidebar id="sidebar-1" title="Sidebar" shadow>
      <div class="px-3 py-2">
        <router-link to="/">Home</router-link>
        <br>
        <router-link to="/Auction/">Auction</router-link>
        <p>---------------</p>
        <p>Auction categorys:</p>
          <div id="nav">
          <div v-for="(asd, index) in category" :key="index" >
            <router-link :to="{name : 'auction',  params: {category: category, category: asd }} " v-model="proov">{{asd}}</router-link>
            <p>{{filteredItems(asd)}}</p>
          </div>
        </div>
      </div>
    </b-sidebar>
  </div>
</template>

<script>
import AuctionDataService from "../../services/AuctionDataService";

export default {


  data() {

    return {

      category:[],
      auctions: []
        };
  },
  methods: {

      uniqueCategory(){
        return[...new Set(this.auctions.map(auction => auction.productCategory))];

    },
    filteredItems(data){
      return this.auctions.filter(function(auction){return auction.productCategory === data}).map(auction=> auction.productName).join()
    },

    retrieveAuctionList() {
      AuctionDataService.getAll()
        .then(response => {
          this.auctions = response.data;
          console.log(this.auctions)
           this.category = this.uniqueCategory();

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


};
</script>

<style>

@import "https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css";


#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>