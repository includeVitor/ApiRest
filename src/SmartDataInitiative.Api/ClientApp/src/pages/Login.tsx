import React, { useState } from "react"
import { authService } from "../services"
import { UserRequest, UserRequestError } from "../types"
import { useHistory } from "react-router-dom"

import Button from '@material-ui/core/Button'
import TextField from '@material-ui/core/TextField'
import Grid from '@material-ui/core/Grid'
import Typography from '@material-ui/core/Typography'
import Link from '@material-ui/core/Link'
import { makeStyles } from '@material-ui/core/styles'
import TouchAppIcon from '@material-ui/icons/TouchApp'
import {FORGOT, SIGNUP} from "../route/CONSTANTS"

const LoginPage: React.FC = (props : any) => { 
    
    const history =  useHistory()
    
    const [values, setValues] = useState({
        email: "",
        password: ""
    } as UserRequest)
 
    const [errors, setErrors] = useState({} as UserRequestError)

    const hasError = (field: string) => !!errors[field]

    const getError = (field: string) => errors[field]   

    function ableToSubmit (value : any) {

        if('email' in errors || 'password' in errors )
            return !(errors.email === "" && errors.password === "" && values.email !== "" && values.password !== "")
        else
            return true
    }

    const handleChange = (e: any) => {
        const input = e.target
        setValues(values => ({
            ...values,
            [input.name]: input.value
        }));
        setErrors({ ...errors, [input.name]: input.validationMessage})
    }

    const handleSubmit = (e: any) => {
        e.preventDefault()

        // client side validation
        const form = e.target
        const formData = new FormData(form)
        const errorMessages = Array.from(formData.keys()).reduce((acc: any, key: any) => {
            acc[key] = form.elements[key].validationMessage
            return acc
        },{})

        setErrors(errorMessages)

        const userData : UserRequest ={
            email: values.email,
            password: values.password
        }
        
        //authentication
        authService.loginUser(userData, history)    
    }

    const handleRedirectForgot = (e :any) => {
        e.preventDefault()
        history.push(FORGOT)
    }

    const handleRedirectRegister = (e: any) => {
        e.preventDefault()
        history.push(SIGNUP)
    }

    const useStyles = makeStyles((theme) => ({
        main:{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            flex: '1 1 0%',
            width: '100%',
            maxWidth: 1000,
            padding: 32,
            justifyContent: 'center'
        },
        content : {
            width: '100%',
            display: 'flex',           
            justifyContent: 'space-between'
        },
        item: {
            display: 'flex',
            flexDirection: 'column',
            alignSelf: 'center',
            width: '100%',
            maxWidth: 480,
            alignItems: 'center'
        },
        form: {
            display: 'flex',
            flexDirection: 'column',
            alignSelf: 'center',
            width: '100%',
            maxWidth: 480,
            alignItems: 'center',
            padding: 68,
            borderRadius: 5,
            border: '1px solid #dadce0',
            backgroundColor: '#fff'
        },
        forgot: {
            marginTop: 15,
            justifyContent: 'flex-start',
            display: 'flex'
        },
        buttonSubmit : {
            marginTop: 40,
            justifyContent: 'flex-end',
            display: 'flex'
        },
        buttonRegister : {
            marginTop: 40,
            justifyContent: 'flex-start',
            display: 'flex'
        }
    }));
    
    const classes = useStyles();
    
    return (  

        <Grid className={classes.main}>

            <Grid className={classes.content}>
                    
                <Grid  className={classes.item}>

                    <TouchAppIcon style={{ fontSize: 75, marginBottom: 10 }}/>

                    <Typography variant="h3" component="h3">
                        Entre na plataforma
                    </Typography>
            
                </Grid>

                <form className={classes.form} noValidate onSubmit={handleSubmit}> 

                    <Grid container>
                        
                        <Grid item lg={12}>
                            <TextField
                                type="email"
                                value={values.email}
                                name="email"
                                onChange={handleChange}
                                margin="normal"
                                label="E-mail" 
                                variant="outlined"
                                autoComplete="email"
                                helperText={getError('email')}
                                error={hasError('email')}
                                autoFocus
                                fullWidth
                                required
                            />  
                        </Grid>
                        
                        <Grid item lg={12}>
                            <TextField
                                type="password"
                                value={values.password}
                                name="password"
                                onChange={handleChange}
                                label="Senha" 
                                variant="outlined"
                                helperText={getError('password')}
                                error={hasError('password')}
                                required
                                fullWidth
                            />  
                        </Grid>

                        <Grid item lg={12} className={classes.forgot}>
                            <Typography>
                                <Link href={FORGOT} onClick={handleRedirectForgot}>
                                    Esqueci minha senha
                                </Link>
                            </Typography>
                        </Grid>

                        <Grid item lg={6} className={classes.buttonRegister}>
                            <Typography>
                                <Link href={SIGNUP} onClick={handleRedirectRegister}>
                                    Registrar
                                </Link>
                            </Typography>
                        </Grid>

                        <Grid item lg={6} className={classes.buttonSubmit}>
                            <Button
                                type="submit"
                                variant="contained"
                                color="primary"
                                size="medium"
                                disabled={ableToSubmit(errors)}
                            >
                                Entrar
                            </Button>
                        </Grid>

                    </Grid>

                </form>
                
            </Grid>
        </Grid>
    )

}
 
export default LoginPage
