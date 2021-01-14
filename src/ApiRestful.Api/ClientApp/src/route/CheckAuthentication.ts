import jwtDecode from "jwt-decode"
import { login, logout } from "../store/ducks/auth"
import api from "../services/api"
import store from "../store"



export const CheckAuthentication = () => {

    const authToken = localStorage.token
    
    if(authToken){
        const decodedToken:any = jwtDecode(authToken)

        if(decodedToken.exp * 1000 < Date.now()){
            store.dispatch(logout())
        }else{
            store.dispatch(login())
            api.defaults.headers.common["Authorization"] = authToken
        }
    }

}