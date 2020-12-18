import {RouteProps } from "react-router-dom";

export interface UserRequest{
    email:string,
    password:string
}

export type UserRequestError = {
    [index: string] :string
}

export interface User{
    id: string,
    name:string 
    email:string
}

export interface AppRouteProps extends RouteProps{
    component: any,
    authenticated: boolean,
    rest?: any
}

export interface Error{
    description: string
}

export interface Errors{
    code: number,
    errors: Error[]
}

export interface Toast{
    time?:number,
    message:string
}

export interface Forgot{
    email: string
}

export interface UserRequestRegister{
    email:string,
    password:string,
    confirmPassword: string
}