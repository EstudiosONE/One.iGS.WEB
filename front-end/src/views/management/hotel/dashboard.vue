<template>
    <div>
        <div>
            <md-table v-if="$store.state.ViewPort.IsXsmall" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckInToday" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Ingresos</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingCheckInToday" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin ingresos hoy" md-icon="flight_land" md-description="No contamos con ingresos para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-xsmall" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Estado">{{ item.Ocupation ? 'Ocupada' : 'Pendiente' }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsSmall" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckInToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Ingresos</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingCheckInToday" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin ingresos hoy" md-icon="flight_land" md-description="No contamos con ingresos para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-small" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Ocupation ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Ocupation ? 'Ocupada' : 'Pendiente' }},    {{ item.Confirmation ? 'Confirmada' : 'Sin confirmar' }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsMedium" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckInToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Ingresos</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingCheckInToday" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin ingresos hoy" md-icon="flight_land" md-description="No contamos con ingresos para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-medium" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Pasajeros">{{ToNumber(item.Adults, '0')}} Adultos, {{ToNumber(item.Childrens, '0')}} Chicos, {{ToNumber(item.Babies, '0')}} Bebes</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Ocupation ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Ocupation ? 'Ocupada' : 'Pendiente' }},    {{ item.Confirmation ? 'Confirmada' : 'Sin confirmar' }}</md-table-cell>
                    <md-table-cell md-label="Ingresa" :class="{'igs-column-delayed': IsDelayed(item)}">{{ item.Ocupation ? 'ya ingresó' : FromNowCheckInToday(item.EntryTime) }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsLarge" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckInToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Ingresos</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingCheckInToday" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin ingresos hoy" md-icon="flight_land" md-description="No contamos con ingresos para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-large" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Pasajeros">{{ToNumber(item.Adults, '0')}} Adultos, {{ToNumber(item.Childrens, '0')}} Chicos, {{ToNumber(item.Babies, '0')}} Bebes</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Ocupation ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Ocupation ? 'Ocupada' : 'Pendiente' }},    {{ item.Confirmation ? 'Confirmada' : 'Sin confirmar' }}</md-table-cell>
                    <md-table-cell md-label="Ingresa" :class="{'igs-column-delayed': IsDelayed(item)}">{{ item.Ocupation ? 'ya ingresó' : FromNowCheckInToday(item.EntryTime) }}</md-table-cell>
                    <md-table-cell md-label="Check Out">{{ ToDateString(item.CheckOut) }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsXlarge" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckInToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Ingresos</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingCheckInToday" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin ingresos hoy" md-icon="flight_land" md-description="No contamos con ingresos para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-xlarge" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Pasajeros">{{ToNumber(item.Adults, '0')}} Adultos, {{ToNumber(item.Childrens, '0')}} Chicos, {{ToNumber(item.Babies, '0')}} Bebes</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Ocupation ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Ocupation ? 'Ocupada' : 'Pendiente' }},    {{ item.Confirmation ? 'Confirmada' : 'Sin confirmar' }}</md-table-cell>
                    <md-table-cell md-label="Ingresa" :class="{'igs-column-delayed': IsDelayed(item)}">{{ item.Ocupation ? 'ya ingresó' : FromNowCheckInToday(item.EntryTime) }}</md-table-cell>
                    <md-table-cell md-label="Check Out">{{ ToDateString(item.CheckOut) }}</md-table-cell>
                </md-table-row>
            </md-table>
        </div>
        <div>
            <md-table v-if="$store.state.ViewPort.IsXsmall" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckOutToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Salidas</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin salidas hoy" md-icon="flight_takeoff" md-description="No contamos con salidas para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-xsmall" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Released ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Released ? 'Libre' : 'Ocupada' }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsSmall" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckOutToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Salidas</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin salidas hoy" md-icon="flight_takeoff" md-description="No contamos con salidas para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-small" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Released ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Released ? 'Libre' : 'Ocupada' }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsMedium" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckOutToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Salidas</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin salidas hoy" md-icon="flight_takeoff" md-description="No contamos con salidas para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-medium" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Pasajeros">{{ToNumber(item.Adults, '0')}} Adultos, {{ToNumber(item.Childrens, '0')}} Chicos, {{ToNumber(item.Babies, '0')}} Bebes</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Released ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Released ? 'Libre' : 'Ocupada' }}</md-table-cell>
                    <md-table-cell md-label="Sale" :class="{'igs-column-delayed': IsDelayed(item)}">{{ item.Released ? 'ya salió' : FromNowCheckOutToday(item.ReleaseTime) }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsLarge" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckOutToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Salidas</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin salidas hoy" md-icon="flight_takeoff" md-description="No contamos con salidas para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-large" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Pasajeros">{{ToNumber(item.Adults, '0')}} Adultos, {{ToNumber(item.Childrens, '0')}} Chicos, {{ToNumber(item.Babies, '0')}} Bebes</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Released ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Released ? 'Libre' : 'Ocupada' }}</md-table-cell>
                    <md-table-cell md-label="Sale" :class="{'igs-column-delayed': IsDelayed(item)}">{{ item.Released ? 'ya salió' : FromNowCheckOutToday(item.ReleaseTime) }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsXlarge" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.CheckOutToday" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Salidas</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingCheckInToday" class="igs-risk-0" md-label="Sin salidas hoy" md-icon="flight_takeoff" md-description="No contamos con salidas para el día de hoy"/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-xlarge" @click="To('/management/hotel/reservation/' + item.Id)" :class="{'igs-column-confirmed': item.Ocupation}">
                    <md-table-cell md-label="Habitacion">{{ item.RoomName }}</md-table-cell>
                    <md-table-cell md-label="Titular">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell md-label="Pasajeros">{{ToNumber(item.Adults, '0')}} Adultos, {{ToNumber(item.Childrens, '0')}} Chicos, {{ToNumber(item.Babies, '0')}} Bebes</md-table-cell>
                    <md-table-cell md-label="Estado"><md-icon>{{item.Released ? 'check_circle' : 'access_time'}}</md-icon> &nbsp; &nbsp; {{ item.Released ? 'Libre' : 'Ocupada' }}</md-table-cell>
                    <md-table-cell md-label="Sale" :class="{'igs-column-delayed': IsDelayed(item)}">{{ item.Released ? 'ya salió' : FromNowCheckOutToday(item.ReleaseTime) }}</md-table-cell>
                </md-table-row>
            </md-table>
        </div>
        <div>
            <md-table v-if="$store.state.ViewPort.IsXsmall" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
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
            <md-table v-if="$store.state.ViewPort.IsSmall" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
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
            <md-table v-if="$store.state.ViewPort.IsMedium" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Reservas sin confirmar</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingPendingReservation" class="igs-risk-0" md-label="Sin riesgos" md-icon="check_circle" md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo."/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-medium" @click="To('/management/hotel/reservation/' + item.Id)">
                    <md-table-cell class="igs-column-risk" :class="RiskClass(item.Risk)"><md-icon>error</md-icon>{{Risk(item.Risk)}}</md-table-cell>
                    <md-table-cell class="igs-column-room" md-label="Habitación" md-sort-by="Room">{{item.RoomName}}</md-table-cell>
                    <md-table-cell class="igs-column-holder" md-label="Titular" md-sort-by="PaxName">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell class="igs-column-checkin" md-label="Check In">{{ ToShortDateString(item.CheckIn) }}</md-table-cell>
                    <md-table-cell class="igs-column-checkin" md-label="Check Out">{{ ToShortDateString(item.CheckOut) }}</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsLarge" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Reservas sin confirmar</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingPendingReservation" class="igs-risk-0" md-label="Sin riesgos" md-icon="check_circle" md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo."/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-large" @click="To('/management/hotel/reservation/' + item.Id)">
                    <md-table-cell class="igs-column-risk" :class="RiskClass(item.Risk)"><md-icon>error</md-icon>{{Risk(item.Risk)}}</md-table-cell>
                    <md-table-cell class="igs-column-room" md-label="Habitación" md-sort-by="Room">{{ToNumber(item.RoomNumber, '000')}} - {{item.RoomName}}</md-table-cell>
                    <md-table-cell class="igs-column-holder" md-label="Titular" md-sort-by="PaxName">{{ item.HolderSurname }}, {{ item.HolderName }}</md-table-cell>
                    <md-table-cell class="igs-column-checkin" md-label="Check In">{{ ToDateString(item.CheckIn) }}</md-table-cell>
                    <md-table-cell class="igs-column-checkin" md-label="Check Out">{{ ToDateString(item.CheckOut) }}</md-table-cell>
                    <md-table-cell class="igs-column-checkin" md-label="Pasajeros">{{ToNumber(item.Adults, '0')}} Adultos, {{ToNumber(item.Childrens, '0')}} Chicos, {{ToNumber(item.Babies, '0')}} Bebes</md-table-cell>
                </md-table-row>
            </md-table>
            <md-table v-if="$store.state.ViewPort.IsXlarge" :mdHeight="240" v-model="this.$store.state.Hotel.Dashboard.PendingReservation" md-sort="Risk" md-sort-order="desc" md-fixed-header class="igs-dashboard-table">
                <md-table-toolbar>
                    <div class="md-toolbar-section-start">
                        <div class="md-title">
                            <h1 class="md-title">Reservas sin confirmar</h1>
                            <md-progress-bar v-show="$store.state.Hotel.Dashboard.GetingPendingReservation" md-mode="indeterminate"></md-progress-bar>
                        </div>
                    </div>
                </md-table-toolbar>
                <md-table-empty-state v-show="!$store.state.Hotel.Dashboard.GetingPendingReservation" class="igs-risk-0" md-label="Sin riesgos" md-icon="check_circle" md-description="Actualmente no cuentas con reservas de riesgo 3 o superior, buen trabajo."/>

                <md-table-row slot="md-table-row" slot-scope="{ item }" class="igs-xlarge" @click="To('/management/hotel/reservation/' + item.Id)">
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
    </div>
</template>

<script>
    import Moment from 'moment'
    import MomentCheckInToday from 'moment'
    import MomentCheckOutToday from 'moment'
    import Numeral from 'numeral'
    MomentCheckInToday.defineLocale('es-CheckInToday', {
        parentLocale: 'es',
        relativeTime : {
                future: "ingresa en %s",
                past:   "retraso de %s",
                s  : 'unos segundos',
                ss : '%d secundos',
                m:  "un minuto",
                mm: "%d minutos",
                h:  "una hora",
                hh: "%d horas",
                d:  "un día",
                dd: "%d días",
                M:  "un mes",
                MM: "%d meses",
                y:  "un año",
                yy: "%d años"
        }
    })
    MomentCheckInToday.locale('es-CheckInToday')
    MomentCheckOutToday.defineLocale('es-CheckOutToday', {
        parentLocale: 'es',
        relativeTime : {
                future: "sale en %s",
                past:   "retraso de %s",
                s  : 'unos segundos',
                ss : '%d secundos',
                m:  "un minuto",
                mm: "%d minutos",
                h:  "una hora",
                hh: "%d horas",
                d:  "un día",
                dd: "%d días",
                M:  "un mes",
                MM: "%d meses",
                y:  "un año",
                yy: "%d años"
        }
    })
    MomentCheckOutToday.locale('es-CheckOutToday')


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
            },
            FromNowCheckInToday: function(value){
                return MomentCheckInToday(value).fromNow()
            },
            IsDelayed: function(value){
                let result = false

                if (value.EntryTime) {
                    if (!value.Ocupation) {
                        result = Moment().isAfter(Moment(value.EntryTime));
                    }
                } else if (value.ReleaseTime) {
                    if (!value.Released) {
                        result = Moment().isAfter(Moment(value.ReleaseTime));
                    }
                }

                return result
            },
            FromNowCheckOutToday: function(value){
                return MomentCheckOutToday(value).fromNow()
            },

        },
        computed: {
            viewport: function(){
                return this.$store.state.ViewPort
            },
        },
        created() {
            this.$store.dispatch('Hotel/Dashboard/GetCheckInToday')
            this.$store.dispatch('Hotel/Dashboard/GetCheckOutToday')
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

    $confirmed-color: md-get-palette-color(green, 700);
    $confirmed-background: md-get-palette-color(green, 100);
    $delayed-color: md-get-palette-color(orange, 600);

    .igs-dashboard-table{
        border-bottom: 1px solid md-get-palette-color(gray, 300);;
        margin-bottom: 24px;
        .md-table-row.igs-column-confirmed{
            .md-icon{
                color: $confirmed-color !important;
            }
            .md-table-cell{
                background-color: $confirmed-background !important;
            }
            background-color: $confirmed-background !important;
            color: $confirmed-color !important;
        }
        .igs-column-delayed{
            color: $delayed-color !important;
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
