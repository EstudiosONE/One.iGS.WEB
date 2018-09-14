import PendingReservation from '@/model/api/hotel/dashboard/PendingReservation'
import { ProcessAuthorization } from '@/scripts/auth/auth'
import { Server } from '@/scripts/axios/axios.config'

export default {
    actions: {
        GetPendingReservation({ commit, rootState }: {commit: any, rootState: any }) {
            commit('SetGetingPendingReservation', true)
            Server.get('hotel/reservation/dashboard/check-in-today')
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
        SetGetingPendingReservation(state: any, value: boolean) {
            state.GetingPendingReservation = value
        },
        GetPendingReservation(state: any, payload: any) {
            state.PendingReservation = payload
        },
    },
    namespaced: true,
    state: {
        GetingPendingReservation: false,
        PendingReservation: [ ],
    },
}