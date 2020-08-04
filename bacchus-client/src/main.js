import Vue from 'vue'
import App from './App.vue'
import router from './router'
import moment from 'moment-timezone'
import { BootstrapVue} from 'bootstrap-vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

moment.tz.setDefault('Europe/Helsinki')

Vue.config.productionTip = false
Vue.use(BootstrapVue)


new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
