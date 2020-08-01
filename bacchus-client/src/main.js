import Vue from 'vue'
import App from './App.vue'
import router from './router'
import moment from 'moment-timezone'

moment.tz.setDefault('Europe/Helsinki')

Vue.config.productionTip = false



new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
