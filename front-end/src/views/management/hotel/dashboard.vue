<template>
  <div>
    <!-- <md-table :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc"  md-fixed-header class="igs-dashboard-pendingreservation"> -->
    <md-table :mdHeight="240" class="igs-dashboard-pendingreservation">
      <md-table-toolbar>
        <div class="md-toolbar-section-start">
                <h1 class="md-title">Reservas sin confirmar:</h1>
        </div>
      </md-table-toolbar>

      <!-- <md-table-empty-state
        class="igs-risk-0"
        md-label="Sin riesgos"
        md-icon="check_circle"
        md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo.">
      </md-table-empty-state> -->
      <md-table-row>
        <md-table-head class="igs-column-Id" md-numeric>Id</md-table-head>
        <md-table-head class="igs-column-RoomName">Habitación</md-table-head>
        <md-table-head>Titular</md-table-head>
        <md-table-head class="igs-column-CheckIn">Check In</md-table-head>
        <md-table-head class="igs-column-CheckOut">Check Out</md-table-head>
        <md-table-head class="igs-column-Risk">Riesgo</md-table-head>
        <md-table-head class="igs-column-Actions"></md-table-head>
      </md-table-row>
      <md-table-row v-for="(item, index) in this.$store.state.Hotel.Dashboard.PendingReservation" :key="index">
          <md-table-cell class="igs-column-Id" md-numeric>{{item.Id}}</md-table-cell>
          <md-table-cell>{{item.RoomName}}</md-table-cell>
          <md-table-cell>{{item.HolderSurname}}, {{item.HolderName}}</md-table-cell>
          <md-table-cell>{{ToDateString(item.CheckIn)}}</md-table-cell>
          <md-table-cell>{{ToDateString(item.CheckOut)}}</md-table-cell>
          <md-table-cell class="igs-column-Risk" :class="RiskClass(item.Risk)">
                <md-icon >error</md-icon>
                <span>{{ Risk(item.Risk) }}</span>
          </md-table-cell>
          <md-table-cell class="igs-column-Actions">
            <md-button class="md-icon-button">
                <md-icon>edit</md-icon>
            </md-button>
        </md-table-cell>
      </md-table-row>
      <!-- <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-numeric class="igs-column-Id" md-label="Id" md-sort-by="Id">{{ item.Id }}</md-table-cell>
        <md-table-cell v-show="viewport.IsXsmall || viewport.IsSmall || viewport.IsMedium" class="igs-column-RoomName" md-label="Habitación" md-sort-by="Room">{{ item.RoomName }}</md-table-cell>
        <md-table-cell v-show="viewport.IsLarge || viewport.IsXlarge" class="igs-column-RoomName" md-label="Habitación" md-sort-by="Room">{{item.RoomNumber}} {{ item.RoomName }}</md-table-cell>
        <md-table-cell class="igs-column-HolderName" md-label="Titular" md-sort-by="PaxName">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
        <md-table-cell class="igs-column-Risk" md-label="Riesgo" md-sort-by="Risk" :class="RiskClass(item.Risk)">
            <md-icon >error</md-icon>
            <span>{{ Risk(item.Risk) }}</span>
        </md-table-cell>
        <md-table-cell class="igs-column-Actions">
            <md-button class="md-icon-button">
                <md-icon>edit</md-icon>
            </md-button>
        </md-table-cell>
      </md-table-row> -->
    </md-table>
  </div>
</template>

<script>
    import Moment from 'moment'
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
    }
</script>

<style lang="scss">
    @import "~vue-material/dist/theme/engine"; // Import the theme engine

    .igs-dashboard-pendingreservation{

        .igs-hide{
            visibility: collapse;
        }
        .igs-column-Id{
            width: 38px;
            border-left: 2px solid md-get-palette-color(white, 500);
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

    .igs-risk-0{
        .md-table-cell-container{
            border-radius: 24px;
            background-color: $risk-0-background !important;
        }
        .md-icon{
            color: $risk-0-color !important;
        }
        span{
            color: $risk-0-color !important;
        }
    }
    .igs-risk-1{
        .md-table-cell-container{
            border-radius: 24px;
            background-color: $risk-1-background !important;
        }
        .md-icon{
            color: $risk-1-color !important;
        }
        span {
            color: $risk-1-color !important;
        }
    }
    .igs-risk-2{
        .md-table-cell-container{
            border-radius: 24px;
            background-color: $risk-2-background !important;
        }
        .md-icon{
            color: $risk-2-color !important;
        }
        span {
            color: $risk-2-color !important;
        }
    }
    .igs-risk-3{
        .md-table-cell-container{
            border-radius: 24px;
            background-color: $risk-3-background !important;
        }
        .md-icon{
            color: $risk-3-color !important;
        }
        span {
            color: $risk-3-color !important;
        }
    }
    .igs-risk-4{
        .md-table-cell-container{
            border-radius: 24px;
            background-color: $risk-4-background !important;
        }
        .md-icon{
            color: $risk-4-color !important;
        }
        span {
            color: $risk-4-color !important;
        }
    }
    .igs-risk-5{
        .md-table-cell-container{
            border-radius: 24px;
            background-color: $risk-5-background !important;
        }
        .md-icon{
            color: $risk-5-color !important;
        }
        span {
            color: $risk-5-color !important;
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
