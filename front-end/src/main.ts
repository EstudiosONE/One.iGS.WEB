import '@/main_js'
import '@/registerServiceWorker'
import router from '@/router'
import store from '@/store'
import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false

new Vue({
  render: (h) => h(App),
  router,
  store,
}).$mount('#app')
