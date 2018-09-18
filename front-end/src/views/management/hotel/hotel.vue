<template>
    <div>
        <router-view/>
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
