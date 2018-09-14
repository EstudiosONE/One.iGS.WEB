import Vue from 'vue'
import Router from 'vue-router'
import p404 from './views/management/404.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  // base: process.env.BASE_URL,
  routes: [
    { path: '*', component: p404},
    { path: '/', redirect: '/portal' },
    {
      path: '/portal',
      component: () => import(/* webpackChunkName: "portal" */ './views/portal/portal.vue'),
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
            { path: '*', component: p404},
          ],
        },
        { path: '*', component: p404},
      ],
    },
  ],
})
