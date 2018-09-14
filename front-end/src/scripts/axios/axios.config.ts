import Axios from 'axios'

export const Server = Axios.create({
    baseURL: 'http://localhost:81/api/',
    // baseURL: 'http://200.108.244.182:81/api/',
    headers: {
        'Accept': 'application/json',
        'Authorization': '',
        'Content-Type': 'application/json',
    },
    timeout: 10000,
})

export default {
    Server,
}