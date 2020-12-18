import React from "react"
import { connect } from "react-redux"
import { Redirect, Route } from "react-router-dom"
import { AppRouteProps } from "../../types"
import {MAIN}  from "../CONSTANTS"

const PublicRoute: React.FC<AppRouteProps> = ({component: Component, authenticated, ...rest}) => {

    return (  
        <Route
            {...rest}
            render={ (props) => authenticated ? <Redirect to={MAIN} /> : <Component {...props} />  }
        />
    )
}

const mapStateToProps = (state:any) => ({
    authenticated : state.auth.isAuthenticated
})
 
export default connect(mapStateToProps) (PublicRoute)