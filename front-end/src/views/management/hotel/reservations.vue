<template>
    <md-table :mdHeight="240" v-model="result" md-fixed-header>
        <md-table-toolbar>
            <div class="md-toolbar-section-start">
                <h1 class="md-title">Reservas</h1>
            </div>
            <div class="md-toolbar-section-end igs-query">
                <md-datepicker class="md-size-20" v-model="query.dateFrom" :md-disabled-dates="disabledDates" md-immediately>
                    <label>Desde</label>
                </md-datepicker> 
                <md-datepicker class="md-size-20" v-model="query.dateTo" :md-disabled-dates="disabledDates" md-immediately>
                    <label>Hasta</label>
                </md-datepicker> 
            </div>
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
            dateFrom: Moment(),
            dateTo: Moment().add(2, 'days'),
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
    .igs-query{
        display: grid;
        grid-gap: 8px;
        grid-template-columns: 20fr 20fr;
        grid-template-rows: 1fr
    }
</style>
<style lang="scss">
  .md-content.md-table-content.md-scrollbar.md-theme-default.md-table-empty{
      height: 0px !important;
  }
</style>


