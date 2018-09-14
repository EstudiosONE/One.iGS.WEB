import { State } from '@/model/store/state'
import Auth from '@/scripts/auth/auth'
import { Server } from '@/scripts/axios/axios.config'
import Axios from 'axios'
import JWT from 'jwt-decode'
import Moment from 'moment'
import Vue from 'vue'
import Vuex from 'vuex'
import Hotel from './model/store/Hotel/module'

Vue.use(Vuex)

const state: State = new State()

export default new Vuex.Store({
    actions: {
        Login(store, {User, Pass}) {
            Server.post('auth/login', {
                Pass,
                User,
            })
            .then((response) => {
                window.localStorage.setItem('token', response.data)
                store.commit('SetAuth')
            })
            .catch((error) => {
                console.log(error.response.status)
            })
        },
    },
    getters: {},
    modules: {
        Hotel,
    },
    mutations: {
        SetAuth() {
            const tokenString = window.localStorage.token
            Auth.ProcessAuthorization(state, tokenString)
        },
        SetViewPort(state, viewport) {
            state.ViewPort = viewport
        },
    },
    state,
})