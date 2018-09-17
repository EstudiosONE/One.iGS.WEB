<template>
  <md-app md-waterfall md-mode="fixed">
    <md-app-toolbar class="md-primary">
      <div class="md-layout md-alignment-center-center" style="width: 100%; min-height: 48px;">
        <div class="md-layout-item md-layout md-alignment-center-left md-size-50">
          <md-button class="md-icon-button" @click="menuVisible = !menuVisible">
            <md-icon style="color: #000000b3">menu</md-icon>
          </md-button>
          <span class="md-title">
            <span>SGH </span>
            <span style="font-family: product_sansbold">Management</span>
          </span>
        </div>
        <div class="md-layout-item md-layout md-alignment-center-right md-size-50">
          <md-button class="md-icon-button">
            <md-icon style="color: #000000b3">person_outline</md-icon>
          </md-button>
        </div>
      </div>
      <div class="md-layout md-alignment-center-left" style="width: 100%; min-height: 48px; padding-bottom: 8px;">
        <md-button class="md-icon-button" @click="$router.go(-1)">
            <md-icon style="color: #000000b3">navigate_before</md-icon>
        </md-button>
        <md-tabs md-sync-route>
            <template slot="md-tab" slot-scope="{ tab }">
                <div class="md-layout md-alignment-center-left">
                    <md-icon>{{ tab.icon }}</md-icon>
                    <md-tooltip md-direction="bottom">{{ tab.label }}</md-tooltip>
                </div>
            </template>
            <md-tab v-for="(item, index) in menu.subModules" :key="index" :to="item.to" :md-label="item.label" :md-icon="item.icon"></md-tab>
        </md-tabs>
      </div>
    </md-app-toolbar>

    <md-app-drawer :md-active.sync="menuVisible" :md-permanent="breakPoint != 'xsmsall'? 'clipped' : null" :md-persistent="breakPoint != 'xsmsall'? 'mini' : null">
       <md-list>
        <md-list-item v-for="(item, index) in menu.modules" :key="index" :to="item.to" @click="menuVisible = false">
          <md-icon>{{ item.icon }}</md-icon>
          <span class="md-list-item-text">{{ item.label }}</span>
          <md-tooltip v-show="menuVisible === false" md-direction="right">{{ item.label }}</md-tooltip>
        </md-list-item>
      </md-list>
    </md-app-drawer>

    <md-app-content class="igs-app">
      <router-view></router-view>
    </md-app-content>
  </md-app>
</template>

<script>
    export default {
        name: 'Flexible',
        data: () => ({
            menuVisible: false,
            params: '',
            winWidth: window.innerWidth,
            menu: {
                modules: [{
                        icon: 'home',
                        label: 'Home',
                        to: '/management/home',
                    },
                    {
                        icon: 'hotel',
                        label: 'Hotel',
                        to: '/management/hotel',
                    },
                    {
                        icon: 'restaurant_menu',
                        label: 'Restaurant',
                        to: '/management/restaurant',
                    },
                    {
                        icon: 'local_mall',
                        label: 'Market',
                        to: '/management/market',
                    },
                    {
                        icon: 'cloud_queue',
                        label: 'Web',
                        to: '/management/web',
                    },
                    {
                        icon: 'settings',
                        label: 'Panel de control',
                        to: '/management/control-panel',
                    },
                ],
            subModules: [
            {
                label: 'Dashboard',
                icon: 'dashboard',
                to: '/management/hotel/dashboard',
            },
            {
                label: 'Reservas',
                icon: 'move_to_inbox',
                to: '/management/hotel/reservations',
            },
            {
                label: 'Ocupación',
                icon: 'transfer_within_a_station',
                to: '/management/hotel/ocupation',
            },
            {
                label: 'Caja',
                icon: 'local_atm',
                to: '/management/hotel/drawer',
            },
            {
                label: 'Informes',
                icon: 'library_books',
                to: '/management/hotel/reports',
            },
        ],

            },
        }),
        mounted() {
            this.params = this.$route.params
            window.addEventListener('resize', () => {
                this.winWidth = window.innerWidth
            })
        },
        updated() {
            this.params = this.$route.params
        },
        computed: {
            isPortal() {
                if (this.params.view) {
                    if (this.params.view === 'portal') {
                        return true
                    } else { return false }
                } else { return false }
            },
            isManagement() {
                if (this.params.view) {
                    if (this.params.view === 'management') {
                        return true
                    } else { return false }
                } else { return false }
            },
            breakPoint() {
                if (this.winWidth < 600) {
                    return 'xsmsall'
                } else if (this.winWidth <= 960) {
                    return 'small'
                } else if (this.winWidth <= 1280) {
                    return 'medium'
                } else if (this.winWidth <= 1920) {
                    return 'xlarge'
                } else {
                    return 'xlarge'
                }
            },
        },
    }
</script>

<style lang="scss">
.igs-app{
    .md-app-scroller{
        overflow: hidden;
    }
}
</style>
