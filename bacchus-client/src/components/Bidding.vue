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
                <td> {{auction.productName}}</td>
                <td> {{auction.productDescription}}</td>
                <td> {{auction.productCategory  }}</td>
                <td> {{auction.biddingEndDate | capitalize}}</td>
                <td> {{datenow}}</td>
              </tbody>
       </table>

        <div  v-if="Errors.length">
                  <p v-for="(error, index) in Errors" v-bind:key="index"> {{error}}</p>
        </div>

        <div>
          <p v-if="!firstNameIsValid" class="error-message"> First Name is required!</p>
          <div class="form-group row">
            <label  class="col-sm-2 col-form-label">First Name</label>
            <div class="col-sm-10">
              <input type="text" class="form-control" v-model="FirstName" >
            </div>
          </div>
          <p v-if="!lastNameIsValid" class="error-message"> Last Name is required!</p>
          <div class="form-group row">
            <label  class="col-sm-2 col-form-label">Last Name</label>
            <div class="col-sm-10">
              <input type="text" class="form-control" v-model="LastName" required >
            </div>
          </div>
          <p v-if="!SumIsValid" class="error-message"> Bidding sum is required!</p>
          <div class="form-group row">
            <label  class="col-sm-2 col-form-label">Sum</label>
            <div class="col-sm-10">
              <input type="number"  class="form-control" v-model.number="Summa" >
            </div>
          </div>
          <button v-on:click="postBid()" class="btn-succsess">Place bidding</button>
        </div>

  </div>
</template>

<script>
import moment from 'moment';
import AuctionDataService from '../services/AuctionDataService';


export default {
  name: "auction",
  props:{
    id:{
      type: String
    },

    auction:{}
  },
  data(){
    return{
        Errors: [],
        datenow :'',
        Summa:0,
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
        AuctionProductId: this.id,
        FirstName: this.FirstName,
        LastName: this.LastName,
        Sum:this.Summa,
        DateTime: this.getData(),

          };
          if(this.formIsValid){
             AuctionDataService.postBidding( data)

            .then(response => {
              console.log(response.data)
              if(response.data === 400){

                this.Errors.push("auction object is expired!")
                setTimeout( () => this.$router.go({name:'auction', params:{category: 'default'}}), 2000);

              }else{
              this.Errors.push("Bid is Placed!")
              setTimeout( () => this.$router.go({name:'auction', params:{category: this.category}}), 2000);
              }
        })
        .catch(e => {
          console.log(e);
        });

        }

    },

  },
  computed:{

      firstNameIsValid(){
      return !!this.FirstName
    },
      lastNameIsValid(){
      return !!this.LastName
    },
    SumIsValid(){
      return !!this.Summa
    },
    formIsValid(){

      return this.firstNameIsValid && this.lastNameIsValid && this.SumIsValid
    }

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