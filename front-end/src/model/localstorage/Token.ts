import { TokenData } from '@/model/localstorage/TokenData'

export class Token {
    public Id: string | undefined
    public Creation: Date | undefined
    public Expiration: Date | undefined
    public Data: TokenData = new TokenData()
    public RequiresNewPassword: boolean = false
}

export default {
    Token,
}
