import Vue from 'vue'
import VueMaterial from 'vue-material'
import AirbnbStyleDatepicker from 'vue-airbnb-style-datepicker'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import 'vue-airbnb-style-datepicker/dist/vue-airbnb-style-datepicker.min.css'

const datepickerOptions = {}

Vue.use(VueMaterial)
Vue.use(AirbnbStyleDatepicker, datepickerOptions)