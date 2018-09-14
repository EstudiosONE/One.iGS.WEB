<template>
    <div>
        <div class="md-layout md-alignment-center-canter">
            <md-tabs md-sync-route>
                <template slot="md-tab" slot-scope="{ tab }">
                    <div class="md-layout md-alignment-center-left">
                        <md-icon>{{ tab.icon }}</md-icon>
                        <md-tooltip md-direction="bottom">{{ tab.label }}</md-tooltip>
                    </div>
                </template>
                <md-tab v-for="(item, index) in menu" :key="index" :to="item.to" :md-label="item.label" :md-icon="item.icon"></md-tab>
            </md-tabs>
        </div>
        <router-view></router-view>
    </div>
</template>

<script>
export default {
    data: () => ({
        menu: [
            {
                label: 'Dashboard',
                icon: 'dashboard',
                to: '/management/hotel/dashboard',
            },
            {
                label: 'Reservas',
                icon: 'move_to_inbox',
                to: '/management/hotel/reservation',
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
    })
}
</script>

<style lang="scss">
    .md-tabs-navigation .md-icon-label{
        height: 48px !important;
        width: 48px;
        .md-layout{
            width: 48px;
        }
    }
</style>
