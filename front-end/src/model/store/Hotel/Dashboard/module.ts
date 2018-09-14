import PendingReservation from '@/model/api/hotel/dashboard/PendingReservation'
import { Server } from '@/scripts/axios/axios.config';
import { ProcessAuthorization } from '@/scripts/auth/auth'

export default {
    actions: {
        GetPendingReservation ({ state, commit, rootState }) {
            Server.get('hotel/reservation/dashboard/check-in-today')
            .then((response) => {
                commit('GetPendingReservation', response.data)
                ProcessAuthorization(rootState, response.headers['authorization'])
            })      
        }
    },
    getters: {

    },
    mutations: {
        GetPendingReservation (state, payload) {
            state.PendingReservation = payload
        },
    },
    namespaced: true,
    state: {
        PendingReservation: [ ],
    },
}