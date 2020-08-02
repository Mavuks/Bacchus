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
        path: "/Auction/:id",
        name: "Auction",
        component: Bidding,
        props: true
      }
    ]
  }
]

const router = new VueRouter({
  mode: 'history',
  routes
})

export default router
