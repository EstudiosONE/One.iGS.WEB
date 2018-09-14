import { Auth } from './auth/auth'
import ViewPort from './state/ViewPort'

export class State {
    public Auth: Auth = new Auth()
    public ViewPort: ViewPort = new ViewPort()
}

export default {
    State,
}
