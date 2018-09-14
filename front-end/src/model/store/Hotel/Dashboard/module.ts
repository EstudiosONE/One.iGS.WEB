import { ProcessAuthorization } from '@/scripts/auth/auth'
import { Server } from '@/scripts/axios/axios.config'

export default {
    actions: {
        GetPendingReservation({ commit, rootState }: {commit: any, rootState: any}) {
            Server.get('hotel/reservation/dashboard/check-in-today')
            .then((response) => {
                commit('GetPendingReservation', response.data)
                ProcessAuthorization(rootState, response.headers['authorization'])
            })
        },
    },
    getters: {

    },
    mutations: {
        GetPendingReservation(state: any, payload: any) {
            state.PendingReservation = payload
        },
    },
    namespaced: true,
    state: {
        PendingReservation: [ ],
    },
}