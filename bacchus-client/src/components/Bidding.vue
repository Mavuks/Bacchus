<template>
  <div>
    <h4>Bidding:</h4>

     <table class="table table-striped border border-dark " >
              <thead class="thead-dark">
               <tr>
                  <th scope="col" >Product Name</th>
                  <th scope="col">Product Description</th>
                  <th scope="col">Product Category</th>
                  <th scope="col">Bidding end date</th>
                  <th scope="col">Current Time</th>
                </tr>
              </thead>
              <tbody >
                <td>{{auction.productName}}</td>
                <td> {{auction.productDescription}}</td>
                <td> {{auction.productCategory  }}</td>
                <td> {{auction.biddingEndDate | capitalize}}</td>
                <td> {{datenow}}</td>

                <!-- <td>  <span class="button is-small btn-success" >Place A bidding </span></td> -->
              </tbody>
       </table>


        <form>
          <div class="form-group row">
            <label  class="col-sm-2 col-form-label">First Name</label>
            <div class="col-sm-10">
              <input type="text" class="form-control" v-model="FirstName" >
            </div>
          </div>
          <div class="form-group row">
            <label  class="col-sm-2 col-form-label">Last Name</label>
            <div class="col-sm-10">
              <input type="text" class="form-control" v-model="LastName" >
            </div>
          </div>
          <div class="form-group row">
            <label  class="col-sm-2 col-form-label">Sum</label>
            <div class="col-sm-10">
              <input type="number"  class="form-control" v-model="Sum" >
            </div>

          </div>

          <button v-on:click="postBid()" class="btn-succsess">Place bidding</button>
        </form>


  </div>
</template>

<script>
import http from "../http-common"
import moment from 'moment';
//import AuctionDataService from '../services/AuctionDataService';


export default {
  name: "auction",
  props: ["auction"],
  data(){
    return{
        Validation: [],
        datenow :'',
        Sum: 0,
        FirstName: "",
        LastName: "",


    }
  },
  methods: {

    getData: function(){
      return  moment(Date()).add(3, "hours");
    },

    time(){
      this.datenow = moment().format('DD.MM.YYYY HH:mm:ss')
    },




    postBid() {
    var data = {
        AuctionProductId: this.auction.productId,
        FirstName: this.FirstName,
        LastName: this.LastName,
        Sum: this.Sum,
        Datetime: this.getData(),

          };
      http.post("api/Biddings", data)

        .then(response => {
            console.log(response)
            console.log(this.FirstName)
            console.log(this.Sum)
           // this.$router.push('/')

        })
        .catch(e => {
          console.log(e);
        });
    },

  },
  mounted() {
    this.interval = setInterval(this.time, 1000);
  },

   beforeDestroy() {
    clearInterval(this.interval)
  },

   filters:
  {
    capitalize: function(value){
    if(value){
      return  moment(String(value)).add(-3, 'hours').format('DD.MM.YYYY HH:mm:ss')
    }
  },

  },
};
</script>