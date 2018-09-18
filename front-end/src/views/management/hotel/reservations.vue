<template>
    <md-table :mdHeight="240" v-model="result" md-fixed-header class="sgh-table">
        <md-table-toolbar class="sgh-table-toolbar">
            <h1 class="md-title sgh-title">Reservas</h1>
            <md-datepicker class="date-from" v-model="query.dateFrom" :md-disabled-dates="disabledDates" md-immediately>
                <label>Desde</label>
            </md-datepicker> 
            <md-datepicker class="date-to" v-model="query.dateTo" :md-disabled-dates="disabledDates" md-immediately>
                <label>Hasta</label>
            </md-datepicker>
            <md-field class="reservation-id">
                <label>Id de reserva</label>
                <md-input></md-input>
            </md-field>
            <md-field class="reservation-holder">
                <label>Titular</label>
                <md-input></md-input>
            </md-field>
        </md-table-toolbar>

        <md-table-empty-state md-label="Upss!" md-icon="hotel" :md-description="emptyResultDescription">
        </md-table-empty-state>

        <md-table-row slot="md-table-row" slot-scope="{ item }" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
        </md-table-row>
    </md-table>
</template>

<script>
import Moment from 'moment'
Moment.locale('es')

export default {
    data: () => ({
        query: {
            dateFrom: Moment().toDate(),
            dateTo: Moment().add(2, 'days').toDate(),
        },
        result: [],
      selectedDate: null,
      disabledDates: date => {
        const day = date.getDay()

        return day === 6 || day === 0
      }
    }),
    computed: {
        emptyResultDescription: function() {
            return "No tenemos reservas entre el " + Moment(this.query.dateFrom).format('dddd DD [de] MMMM [de] YYYY') + " y el " + Moment(this.query.dateTo).format('dddd DD [de] MMMM [de] YYYY')
        }
    },
}
</script>

<style lang="scss" scoped>
    .sgh-table{
        .sgh-table-toolbar{
            height: 128px;
            display: grid;
            grid-template-columns: repeat(12, 1fr);
            grid-template-rows: repeat(2, 64px);
            grid-gap: 8px;
        }

        @media (max-width: 599px) {
            .sgh-table-toolbar{
                .sgh-title{
                    visibility: collapse;
                }
                .date-from{
                    grid-area: 1 / 1 / span 1 / span 6;
                }
                .date-to{
                    grid-area: 1 / 7 / span 1 / span 6;
                }
                .reservation-id{
                    grid-area: 2 / 1 / span 1 / span 6;
                }
                .reservation-holder{
                    grid-area: 2 / 7 / span 1 / span 6;
                }
            }
        }
        @media (min-width: 600px) {
            .sgh-table-toolbar{
                .sgh-title{
                    grid-area: 1 / 1 / span 1 / span 4;
                }
                .date-from{
                    grid-area: 1 / 5 / span 1 / span 4;
                }
                .date-to{
                    grid-area: 1 / 9 / span 1 / span 4;
                }
                .reservation-id{
                    grid-area: 2 / 5 / span 1 / span 4;
                }
                .reservation-holder{
                    grid-area: 2 / 9 / span 1 / span 4;
                }
            }
        }
        @media (min-width: 961px) {
            .sgh-table-toolbar{
                .sgh-title{
                    grid-area: 1 / 1 / span 1 / span 6;
                }
                .date-from{
                    grid-area: 1 / 7 / span 1 / span 3;
                }
                .date-to{
                    grid-area: 1 / 10 / span 1 / span 3;
                }
                .reservation-id{
                    grid-area: 2 / 7 / span 1 / span 3;
                }
                .reservation-holder{
                    grid-area: 2 / 10 / span 1 / span 3;
                }
            }
        }
        @media (min-width: 1281px) {
            .sgh-table-toolbar{
                .sgh-title{
                    grid-area: 1 / 1 / span 1 / span 6;
                }
                .date-from{
                    grid-area: 1 / 9 / span 1 / span 2;
                }
                .date-to{
                    grid-area: 1 / 11 / span 1 / span 2;
                }
                .reservation-id{
                    grid-area: 2 / 9 / span 1 / span 2;
                }
                .reservation-holder{
                    grid-area: 2 / 11 / span 1 / span 2;
                }
            }
        }
        @media (min-width: 1921px) {
            .sgh-table-toolbar{
                .sgh-title{
                    grid-area: 1 / 1 / span 1 / span 6;
                }
                .date-from{
                    grid-area: 1 / 11 / span 1 / span 1;
                }
                .date-to{
                    grid-area: 1 / 12 / span 1 / span 1;
                }
                .reservation-id{
                    grid-area: 2 / 11 / span 1 / span 1;
                }
                .reservation-holder{
                    grid-area: 2 / 12 / span 1 / span 1;
                }
            }
        }
    }    
    .igs-query{
        width: 50vw;
        display: grid;
        grid-gap: 8px;
        grid-template-columns: 20fr 20fr;
        grid-template-rows: 1fr;
    }
</style>
<style lang="scss">
  .md-content.md-table-content.md-scrollbar.md-theme-default.md-table-empty{
      height: 0px !important;
  }
</style>


