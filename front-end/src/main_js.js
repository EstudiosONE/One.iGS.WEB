import Vue from 'vue'
import VueMaterial from 'vue-material'
import HotelDatePicker from 'vue-hotel-datepicker'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import './styles/fonts.css';

Vue.use(VueMaterial)
Vue.component('HotelDatePicker', HotelDatePicker)