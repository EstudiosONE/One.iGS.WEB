import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';
import p404 from './views/management/404.vue'

Vue.use(Router);

export default new Router({
  mode: 'history',
  // base: process.env.BASE_URL,
  routes: [
    { path: '*', component: p404},
    { path: '/', redirect: '/management' },
    {
      path: '/portal',
      component: () => import(/* webpackChunkName: "portal" */ './views/portal/portal.vue'),
      redirect: '/portal/home',
      children: [
        {
          path: '/portal/home',
          component: () => import(/* webpackChunkName: "portal-home" */ './views/portal/Home.vue')
        },
      ]
    },
    {
      path: '/management',
      component: () => import(/* webpackChunkName: "management" */ './views/management/management.vue'),
      redirect: '/management/home',
      children: [
        {
          path: 'hotel',
          component: () => import(/* webpackChunkName: "management-hotel" */ './views/management/hotel/hotel.vue'),
          redirect: 'hotel/dashboard',
          children: [
            {
              path: 'dashboard',
              component: () => import(/* webpackChunkName: "management-hotel-dashboard" */ './views/management/hotel/dashboard.vue'),
            },
            {
              path: 'reservations',
              component: () => import(/* webpackChunkName: "management-hotel-reservations" */ './views/management/hotel/reservations.vue'),
            },
            { path: '*', component: p404},
          ]
        },
        { path: '*', component: p404},
      ]
    },
  ],
});
