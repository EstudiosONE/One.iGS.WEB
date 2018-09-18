import {
    Token,
} from '@/model/localstorage/Token'
import {
    Auth,
} from '@/model/store/auth/auth'
import {
    State,
} from '@/model/store/state'
import JWT from 'jwt-decode'
import Moment from 'moment'
import {
    Server,
} from '../axios/axios.config'

export function ProcessAuthorization(state: State, jwt: string) {
    if (jwt) {
        const tokendata: Token = JWT(jwt)
        if (Moment().isBefore(Moment(tokendata.Expiration))) {
            state.Auth.NeedLogin = false
            state.Auth.Token = tokendata
            state.Auth.TokenBearer = 'Bearer ' + jwt
        } else {
            console.log('token fuera de fecha')
            state.Auth.NeedLogin = true
            state.Auth.Token = undefined
            state.Auth.TokenBearer = undefined
        }
        window.localStorage.setItem('token', jwt)
    } else {
        console.log('jwt nulo')
        state.Auth = new Auth()
    }
    Server.defaults.headers.Authorization = state.Auth.TokenBearer
}

export default {
    ProcessAuthorization,
}