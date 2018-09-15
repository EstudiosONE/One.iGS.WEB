import Axios from 'axios'

export const Server = Axios.create({
    // baseURL: 'http://localhost:81/api/',
    baseURL: window.location.protocol + '//' + window.location.hostname + ':81/api/',
    headers: {
        'Accept': 'application/json',
        'Authorization': '',
        'Content-Type': 'application/json',
    },
    timeout: 1000000000000,
})

export default {
    Server,
}