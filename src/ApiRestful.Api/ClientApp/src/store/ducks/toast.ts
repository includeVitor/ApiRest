import { Action } from "redux"
import { toast } from "react-toastify";
import { Toast } from "../../types"

interface ToastState{ 
    time?: number,
    message: string
}

const INFO = 'toast/info'
const SUCCESS = 'toast/success'
const WARNING = 'toast/warning'
const ERROR = 'toast/error'

interface InfoAction extends Action<typeof INFO> {
    payload: Toast
}
interface SuccessAction extends Action<typeof SUCCESS> {
    payload: Toast
}
interface WarningAction extends Action<typeof WARNING> {
    payload: Toast
}
interface ErrorAction extends Action<typeof ERROR> {
    payload: Toast
}

export const info = (toast: Toast): InfoAction => ({
    type: INFO,
    payload: toast
})

export const success = (toast: Toast): SuccessAction => ({
    type: SUCCESS,
    payload: toast
})

export const warning = (toast : Toast): WarningAction => ({
    type:WARNING,
    payload: toast
})

export const error = (toast: Toast): ErrorAction => ({
    type: ERROR,
    payload: toast
})

const initialState: ToastState = {
    time : 5000,
    message: ""
}

const toastReducer = (
    state: ToastState = initialState,
    action: InfoAction | SuccessAction | WarningAction | ErrorAction
) => {
    switch(action.type){

        case INFO:
            
            toast.info(action.payload.message, {autoClose: action.payload.time})
            return{
                ...state
            }

        case SUCCESS:
            toast.success(action.payload.message, {autoClose: action.payload.time})
            return{
                ...state
            }

        case WARNING:
            toast.warning(action.payload.message, {autoClose: action.payload.time})
            return{
                ...state
            }

        case ERROR:
            toast.error(action.payload.message, {autoClose: action.payload.time})
            return{
                ...state
            }

        default:
            return state
    }
}

export default toastReducer