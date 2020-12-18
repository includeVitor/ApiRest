import { Grid, makeStyles, Typography, TextField, Button, Link } from "@material-ui/core";
import React, { useState } from "react"
import EqualizerRoundedIcon from '@material-ui/icons/EqualizerRounded';
import {LOGIN} from "../route/CONSTANTS"
import { useHistory } from "react-router-dom";
import { UserRequestError, UserRequestRegister } from "../types"
import { authService } from "../services"

const SignupPage: React.FC = () => {


    const history = useHistory()

    const [errors, setErrors] = useState({} as UserRequestError)

    const [values, setValues] = useState({email: "", password: "", confirmPassword: ""} as UserRequestRegister)

    const handleSubmit = (e: any) => {
       e.preventDefault() 
        
      if(values.password !== values.confirmPassword){
        setErrors({...errors, confirmPassword: "Senhas não conferem"})  
        return
      }

       // client side validation
       const form = e.target
       const formData = new FormData(form)
       const errorMessages = Array.from(formData.keys()).reduce((acc: any, key: any) => {
           acc[key] = form.elements[key].validationMessage
           return acc
       },{})

       setErrors(errorMessages)

        const userRegisterData : UserRequestRegister ={
            email: values.email,
            password: values.password,
            confirmPassword: values.confirmPassword
        }

        //registration
        authService.registerUser(userRegisterData, history)
    }

    const handleChange = (e: any) => {
        const input = e.target
        setValues(values => ({
            ...values,
            [input.name]: input.value
        }));
        setErrors({ ...errors, [input.name]: input.validationMessage})
    }

    const handleRedirectLogin = (e: any) => {
        e.preventDefault()
        history.push(LOGIN)
    }

    function ableToSubmit (value : any) {

        if('email' in errors || 'password' in errors || 'confirmPassword')
            return !(errors.email === "" && errors.password === "" && errors.confirmPassword === "" && values.email !== "" && values.password !== "" && values.confirmPassword !== "")
        else
            return true
    }

    const hasError = (field: string) => !!errors[field]

    const getError = (field: string) => errors[field]  

    const useStyles = makeStyles((theme) => ({
        main:{
            display: 'flex',
            flexDirection: 'column',
            flex: '1 1 0%',
            width: '100%',
            maxWidth: 1000,
            padding: 32,
            justifyContent: 'center'
        },
        content: {
            width: '100%',
            display: 'flex',
            justifyContent: 'space-between'
        },
        title: {
            textAlign: 'center',
            fontWeight: 'bold'
        },
        registerForm: {
            display: 'flex',
            flexDirection: 'column',
            width: '100%',
            maxWidth: 480,
            padding: 25,
            marginTop: 15,
            borderRadius: 5,
            alignItems: 'center',
            border: '1px solid #dadce0',
            backgroundColor: '#fff'
        },
        item: {
            display: 'flex',
            flexDirection: 'column',
            alignSelf: 'center',
            width: '100%',
            maxWidth: 480,
            alignItems: 'center',
            padding: 25
        },
        registerButton:{
            display: 'flex',
            justifyContent: 'flex-end',
            marginTop: 15
        },
        titleBack:{
            marginTop:25,
            textAlign: 'start'       
        }
    }))

    const classes = useStyles()


    return (  
        <Grid className={classes.main}>
            <Grid className={classes.content}>
                <form className={classes.registerForm} noValidate onSubmit={handleSubmit}>
                    <Grid container>

                        <Grid item lg={12}>
                            <Typography variant="h5" className={classes.title}>
                                Crie sua conta
                            </Typography>
                        </Grid>

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
                                margin="normal"
                                label="Sua senha" 
                                variant="outlined"
                                helperText={getError('password')}
                                error={hasError('password')}
                                fullWidth
                                required
                            />  
                        </Grid>

                        <Grid item lg={12}>
                            <TextField
                                type="password"
                                value={values.confirmPassword}
                                name="confirmPassword"
                                onChange={handleChange}
                                margin="normal"
                                label="Confirme sua senha" 
                                variant="outlined"
                                helperText={getError('confirmPassword')}
                                error={hasError('confirmPassword')}
                                fullWidth
                                required
                            />  
                        </Grid>

                        <Grid item lg={12} className={classes.registerButton}>
                            <Button
                                    type="submit"
                                    variant="contained"
                                    color="primary"
                                    size="medium"
                                    disabled={ableToSubmit(errors)}
                                >
                                    Cadastrar
                            </Button>
                        </Grid>
                    </Grid>
                </form>
            
                <Grid className={classes.item}>

                     <EqualizerRoundedIcon style={{ fontSize: 75, marginBottom: 10}}/>

                    <Typography variant="h4"  style={{textAlign: 'center'}}>
                        Gerencie projetos com excelência
                    </Typography>

                    <Grid item lg={12}>
                        <Typography className={classes.titleBack}>
                            <Link href={LOGIN} onClick={handleRedirectLogin}>
                                Voltar para Login
                            </Link>
                        </Typography>
                    </Grid>
            
                </Grid>
            </Grid>
        </Grid>
    );
}
 
export default SignupPage;