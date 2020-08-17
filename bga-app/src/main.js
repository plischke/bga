import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import Router from 'vue-router'

import mainPage from './views/mainPage.vue'
import virtualScorecard from './views/virtualScorecard.vue'

Vue.config.productionTip = false
Vue.prototype.$http = axios
Vue.use(Vuetify);
Vue.use(Router)

const router = new Router({
  mode:'history',
  routes: [
    { path: '/', component: mainPage},
    {path: '/scorecard', component: virtualScorecard}
  ]
})

new Vue({
  router,
  vuetify: new Vuetify(),
  render: h => h(App)
}).$mount('#app')
