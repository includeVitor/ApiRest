import React from "react"
import { Switch, BrowserRouter as Router } from "react-router-dom"

import PrivateRoute from './PrivateRoute'
import PublicRoute from './PublicRoute'

import {LOGIN, SIGNUP, FORGOT, MAIN} from "./CONSTANTS"

import Main from "../pages/Main"
import Login from "../pages/Login"
import Signup from "../pages/Signup"
import Forgot from "../pages/Forgot"


const Routes: React.FC = () => {
    return (
        <Router>
            <Switch>
                
                {/* Private Routes */}
                <PrivateRoute exact path={MAIN} component={Main} />


                {/* Public Routes */}
                <PublicRoute exact path={LOGIN} component={Login} />
                <PublicRoute exact path={SIGNUP} component={Signup} />
                <PublicRoute exact path={FORGOT} component={Forgot} />

            </Switch>
        </Router>
    );
}
 
export default Routes
