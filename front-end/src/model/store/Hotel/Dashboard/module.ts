import PendingReservation from '@/model/api/hotel/dashboard/PendingReservation'
import { ProcessAuthorization } from '@/scripts/auth/auth'
import { Server } from '@/scripts/axios/axios.config'

export default {
    actions: {
        GetCheckInToday({ commit, rootState }: {commit: any, rootState: any }) {
            commit('SetGetingCheckInToday', true)
            Server.get('hotel/reservation/dashboard/check-in-today')
            .then((response) => {
                commit('GetCheckInToday', response.data)
                ProcessAuthorization(rootState, response.headers['authorization'])
                commit('SetGetingCheckInToday', false)
            })
        },
        GetCheckOutToday({ commit, rootState }: {commit: any, rootState: any }) {
            commit('SetGetingCheckOutToday', true)
            Server.get('hotel/reservation/dashboard/check-out-today')
            .then((response) => {
                commit('GetCheckOutToday', response.data)
                ProcessAuthorization(rootState, response.headers['authorization'])
                commit('SetGetingCheckOutToday', false)
            })
        },
        GetPendingReservation({ commit, rootState }: {commit: any, rootState: any }) {
            commit('SetGetingPendingReservation', true)
            Server.get('hotel/reservation/dashboard/pending-reservations')
            .then((response) => {
                commit('GetPendingReservation', response.data)
                ProcessAuthorization(rootState, response.headers['authorization'])
                commit('SetGetingPendingReservation', false)
            })
        },
    },
    getters: {

    },
    mutations: {
        SetGetingCheckInToday(state: any, value: boolean) {
            state.GetingCheckInToday = value
        },
        GetCheckInToday(state: any, payload: any) {
            state.CheckInToday = payload
        },
        SetGetingCheckOutToday(state: any, value: boolean) {
            state.GetingCheckOutToday = value
        },
        GetCheckOutToday(state: any, payload: any) {
            state.CheckOutToday = payload
        },
        SetGetingPendingReservation(state: any, value: boolean) {
            state.GetingPendingReservation = value
        },
        GetPendingReservation(state: any, payload: any) {
            state.PendingReservation = payload
        },
    },
    namespaced: true,
    state: {
        GetingCheckInToday: false,
        CheckInToday: [ ],
        GetingCheckOutToday: false,
        CheckOutToday: [ ],
        GetingPendingReservation: false,
        PendingReservation: [ ],
    },
}