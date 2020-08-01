import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import AuctionList from "../components/AuctionList"
import Bidding from "../components/Bidding"



Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },

  {
    path: '/Auction/:category?',
    name: 'auction',
    component: AuctionList,
    props:(route) => ({ category: route.params.category || '' }),
    children: [
      {
        path: "/Auction/",
        name: "Bidding",
        component: Bidding,
        props: true
      }
    ]
  }
]

const router = new VueRouter({
  routes
})

export default router
