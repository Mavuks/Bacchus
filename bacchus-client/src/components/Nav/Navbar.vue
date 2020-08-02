<template>
      <div id="nav">
        <router-link to="/">Home</router-link> |
        <router-link to="/Auction/">Auction</router-link> |
          <div v-for="(asd, index) in category" :key="index">

          <router-link :to="{name : 'auction',  params: {category: category, category: asd }}">{{asd}}</router-link> |

          </div>

     <!--  <router-link to="/">Home</router-link> |
      <router-link to="/Auction">Auction</router-link> |
      <router-link to="/Auction/foo">Auction</router-link> |
      <router-link to="/Auction">proov</router-link> | -->

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
  computed:{

/*
    uniqueCategory(){
        return[...new Set(this.auctions.map(auction => auction.productCategory))];

    } */
  }
/*   filters:
  {
    capitalize: function(value){
    if(value){
      return  moment(String(value)).add(-3, 'hours').format('DD.MM.YYYY HH:mm:ss')
    }
  }
  }, */
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