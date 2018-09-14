<template>
    <div>
        <md-table v-if="$store.state.ViewPort.IsXsmall" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-pendingreservation">
            <md-table-toolbar>
                <div class="md-toolbar-section-start">
                    <div class="md-title">
                        <h1 class="md-title">Reservas sin confirmar</h1>
                        <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                    </div>
                </div>
            </md-table-toolbar>
            <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingPendingReservation" class="igs-risk-0" md-label="Sin riesgos" md-icon="check_circle" md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo."/>

            <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-xsmall">
                <md-table-cell class="igs-column-risk" :class="RiskClass(item.Risk)"><md-icon>error</md-icon></md-table-cell>
                <md-table-cell class="igs-column-holder" md-label="Titular" md-sort-by="PaxName">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Estadía">{{ ToShortDateString(item.CheckIn) }} al {{ ToShortDateString(item.CheckOut) }}</md-table-cell>
            </md-table-row>
        </md-table>
        <md-table v-if="$store.state.ViewPort.IsSmall" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-pendingreservation">
            <md-table-toolbar>
                <div class="md-toolbar-section-start">
                    <div class="md-title">
                        <h1 class="md-title">Reservas sin confirmar</h1>
                        <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                    </div>
                </div>
            </md-table-toolbar>
            <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingPendingReservation" class="igs-risk-0" md-label="Sin riesgos" md-icon="check_circle" md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo."/>

            <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-small">
                <md-table-cell class="igs-column-risk" :class="RiskClass(item.Risk)"><md-icon>error</md-icon></md-table-cell>
                <md-table-cell class="igs-column-room" md-label="Habitación" md-sort-by="Room">{{item.RoomName}}</md-table-cell>
                <md-table-cell class="igs-column-holder" md-label="Titular" md-sort-by="PaxName">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Estadía">{{ ToShortDateString(item.CheckIn) }} al {{ ToShortDateString(item.CheckOut) }}</md-table-cell>
            </md-table-row>
        </md-table>
        <md-table v-if="$store.state.ViewPort.IsMedium" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-pendingreservation">
            <md-table-toolbar>
                <div class="md-toolbar-section-start">
                    <div class="md-title">
                        <h1 class="md-title">Reservas sin confirmar</h1>
                        <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                    </div>
                </div>
            </md-table-toolbar>
            <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingPendingReservation" class="igs-risk-0" md-label="Sin riesgos" md-icon="check_circle" md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo."/>

            <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-small" @click="To('/management/hotel/reservation/' + item.Id)">
                <md-table-cell class="igs-column-risk" :class="RiskClass(item.Risk)"><md-icon>error</md-icon>{{Risk(item.Risk)}}</md-table-cell>
                <md-table-cell class="igs-column-room" md-label="Habitación" md-sort-by="Room">{{item.RoomName}}</md-table-cell>
                <md-table-cell class="igs-column-holder" md-label="Titular" md-sort-by="PaxName">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Check In">{{ ToShortDateString(item.CheckIn) }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Check Out">{{ ToShortDateString(item.CheckOut) }}</md-table-cell>
            </md-table-row>
        </md-table>
        <md-table v-if="$store.state.ViewPort.IsLarge" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-pendingreservation">
            <md-table-toolbar>
                <div class="md-toolbar-section-start">
                    <div class="md-title">
                        <h1 class="md-title">Reservas sin confirmar</h1>
                        <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                    </div>
                </div>
            </md-table-toolbar>
            <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingPendingReservation" class="igs-risk-0" md-label="Sin riesgos" md-icon="check_circle" md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo."/>

            <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-small" @click="To('/management/hotel/reservation/' + item.Id)">
                <md-table-cell class="igs-column-risk" :class="RiskClass(item.Risk)"><md-icon>error</md-icon>{{Risk(item.Risk)}}</md-table-cell>
                <md-table-cell class="igs-column-room" md-label="Habitación" md-sort-by="Room">{{ToNumber(item.RoomNumber, '000')}} - {{item.RoomName}}</md-table-cell>
                <md-table-cell class="igs-column-holder" md-label="Titular" md-sort-by="PaxName">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Check In">{{ ToDateString(item.CheckIn) }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Check Out">{{ ToDateString(item.CheckOut) }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Pasajeros">{{ToNumber(item.Adults, '0')}} Adultos, {{ToNumber(item.Childrens, '0')}} Chicos, {{ToNumber(item.Babies, '0')}} Bebes</md-table-cell>
            </md-table-row>
        </md-table>
        <md-table v-if="$store.state.ViewPort.IsXlarge" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-pendingreservation">
            <md-table-toolbar>
                <div class="md-toolbar-section-start">
                    <div class="md-title">
                        <h1 class="md-title">Reservas sin confirmar</h1>
                        <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                    </div>
                </div>
            </md-table-toolbar>
            <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingPendingReservation" class="igs-risk-0" md-label="Sin riesgos" md-icon="check_circle" md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo."/>

            <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-small" @click="To('/management/hotel/reservation/' + item.Id)">
                <md-table-cell class="igs-column-risk" :class="RiskClass(item.Risk)"><md-icon>error</md-icon>{{Risk(item.Risk)}}</md-table-cell>
                <md-table-cell class="igs-column-room" md-label="Habitación" md-sort-by="Room">{{ToNumber(item.RoomNumber, '000')}} - {{item.RoomName}}</md-table-cell>
                <md-table-cell class="igs-column-holder" md-label="Titular" md-sort-by="PaxName">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Check In">{{ ToDateString(item.CheckIn) }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Check Out">{{ ToDateString(item.CheckOut) }}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Adultos" md-numeric>{{ToNumber(item.Adults, '0')}}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Chicos" md-numeric>{{ToNumber(item.Childrens, '0')}}</md-table-cell>
                <md-table-cell class="igs-column-checkin" md-label="Bebes" md-numeric>{{ToNumber(item.Babies, '0')}}</md-table-cell>
            </md-table-row>
        </md-table>
    </div>
</template>

<script>
    import Moment from 'moment'
    import Numeral from 'numeral'

    export default {
        name: 'TableSearch',
        data: () => ({
            search: null,
            searched: [],
        }),
        methods: {
            Risk: function(risk) {
                if (risk === 0) return "Sin Riesgo"
                if (risk === 1) return "Muy Bajo"
                if (risk === 2) return "Bajo"
                if (risk === 3) return "Medio"
                if (risk === 4) return "Alto"
                if (risk === 5) return "Muy Alto"
            },
            RiskClass: function(risk) {
                return "igs-risk-" + risk;
            },
            ToDateString: function(date) {
                return Moment(date).format('DD/MM/YYYY')
            },
            ToShortDateString: function(date) {
                return Moment(date).format('DD/MM')
            },
            ToNumber: function(number, format) {
                return Numeral(number).format(format);
            },
            To: function(uri) {
                this.$router.push(uri)
            }
        },
        computed: {
            viewport: function(){
                return this.$store.state.ViewPort
            },
            // pendingReservationCount: function(){
            //     if(this.$store.state.Hotel.Dashboard.PendingReservation) {
            //         return this.$store.state.Hotel.Dashboard.PendingReservation.length
            //     } else {
            //         return 0
            //     }
            // }
        },
        created() {
            this.$store.dispatch('Hotel/Dashboard/GetPendingReservation')
        },
        mounted() {

        },
        destroyed() {
            this.$store.commit('Hotel/Dashboard/GetPendingReservation', [])
        },
    }
</script>

<style lang="scss">
    @import "~vue-material/dist/theme/engine"; // Import the theme engine
    $risk-0-color: md-get-palette-color(teal, 500);
    $risk-0-background: md-get-palette-color(teal, 100);
    $risk-1-color: md-get-palette-color(lightblue, A200);
    $risk-1-background: md-get-palette-color(lightblue, 100);
    $risk-2-color: md-get-palette-color(blue, A200);
    $risk-2-background: md-get-palette-color(blue, 100);
    $risk-3-color: md-get-palette-color(orange, A200);
    $risk-3-background: md-get-palette-color(orange, 100);
    $risk-4-color: md-get-palette-color(deeporange, A200);
    $risk-4-background: md-get-palette-color(deeporange, 100);
    $risk-5-color: md-get-palette-color(red, A200);
    $risk-5-background: md-get-palette-color(red, 100);

    .igs-dashboard-pendingreservation{
        .igs-xsmall, .igs-small, {
            .igs-column-risk{
                // .md-table-cell-container{
                //     padding-right: 2px;
                //     padding-left: 12px;
                // }
                // width: 60px;
            }
            .igs-column-risk.igs-risk-0{
                .md-icon{
                    color: $risk-0-color !important;
                }
            }
            .igs-column-risk.igs-risk-1{
                .md-icon{
                    color: $risk-1-color !important;
                }
            }
            .igs-column-risk.igs-risk-2{
                .md-icon{
                    color: $risk-2-color !important;
                }
            }
            .igs-column-risk.igs-risk-3{
                .md-icon{
                    color: $risk-3-color !important;
                }
            }
            .igs-column-risk.igs-risk-4{
                .md-icon{
                    color: $risk-4-color !important;
                }
            }
            .igs-column-risk.igs-risk-5{
                .md-icon{
                    color: $risk-5-color !important;
                }
            }
        }
        .igs-hide{
            visibility: collapse;
        }
        .igs-column-Id{
            width: 38px;
            border-left: 2px solid md-get-palette-color(white, 500);
        }
        .igs-column-RoomNumber{
            width: 60px;
        }
        .igs-column-RoomName{
            width: 160px;
        }
        .igs-column-CheckIn{
            width: 80px;
        }
        .igs-column-CheckOut{
            width: 80px;
        }
        .igs-column-Risk{
            width: 160px;
        }
        .igs-column-Actions{
            width: 120px;
        }
        .md-table-row:hover{
            .md-table-cell{
                background-color: white !important;
            }
            .igs-column-Id{
                border-left: 2px solid md-get-palette-color(blue, A200);
            }
        }
    }

    .igs-risk-null{
        color: transparent !important
    }
    .igs-risk-very-low{
        color: md-get-palette-color(lightblue, A200) !important
    }
    .igs-risk-low{
        .md-table-cell-container{
            border-radius: 24px;
            background-color: md-get-palette-color(blue, 100) !important;
        }
        .md-icon{
            color: md-get-palette-color(blue, A200) !important;
        }
        color: md-get-palette-color(blue, A200) !important;
    }
    .igs-risk-medium{
        color: md-get-palette-color(orange, A200) !important
    }
    .igs-risk-high{
        color: md-get-palette-color(deeporange, A200) !important
    }
    .igs-risk-very-high{
        color: md-get-palette-color(red, A200) !important
    }

  .md-field {
    max-width: 300px;
  }
  .md-content.md-table-content.md-scrollbar.md-theme-default.md-table-empty{
      height: 0px !important;
  }
  .Hight{
      color: red;
  }
</style>
