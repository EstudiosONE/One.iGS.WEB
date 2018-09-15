<template>
  <md-app md-waterfall md-mode="fixed">
    <md-app-toolbar class="md-primary">
      <div class="md-layout md-alignment-center-center" style="width: 100%">
        <div class="md-layout-item md-layout md-alignment-center-left md-size-50">
          <md-button class="md-icon-button" @click="menuVisible = !menuVisible">
            <md-icon>menu</md-icon>
          </md-button>
          <span class="md-title">
            <span>SGH </span>
            <span style="font-family: product_sansbold">Management</span>
          </span>
        </div>
        <div class="md-layout-item md-layout md-alignment-center-right md-size-50">
          <md-button class="md-icon-button">
            <md-icon>person_outline</md-icon>
          </md-button>
        </div>
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
