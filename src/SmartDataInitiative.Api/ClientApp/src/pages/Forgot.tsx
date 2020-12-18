import React, { useState } from "react"
import { Grid, Typography, TextField, Button, Link } from "@material-ui/core"
import { makeStyles } from '@material-ui/core/styles'

import {LOGIN} from "../route/CONSTANTS"
import { useHistory } from "react-router-dom"
import { Forgot, UserRequestError } from "../types"
import { authService } from "../services"

const ForgetPage: React.FC = () => {
    
    const history = useHistory()


    const [email, setEmail] = useState()
    const [errors, setErrors] = useState({} as UserRequestError)

    const handleRedirectLogin = (e : any) => {
        e.preventDefault()
        history.push(LOGIN)
    }

    const handleSubmit = (e: any) => {
        e.preventDefault()
        const form = e.target
        const formData = new FormData(form)
        const errorMessages = Array.from(formData.keys()).reduce((acc: any, key: any) => {
            acc[key] = form.elements[key].validationMessage
            return acc
        },{})

        setErrors(errorMessages)

        //forgot action
        
    }

    const handleChange = (e: any) => {
        const input = e.target
        setEmail(input.value)
        setErrors({...errors, [input.name] : input.validationMessage})
    }

    const hasError = (field: string) => !!errors[field]

    const getError = (field: string) => errors[field]   

    const useStyles = makeStyles((theme) => ({

        main:{
            display:'flex',
            flexDirection: 'column',
            alignItems: 'center',
            flex: '1 1 0%',
            width: '100%',
            maxWidth: 450,
            padding:32,
            justifyContent: 'center'
        },
        title:{
            textAlign: 'center',
            fontWeight: 'bold',
            marginBottom: 20
        },
        forgotButton: {
            marginTop: 8
        },
        backLink:{
            marginTop: 12,
            textAlign: 'center'
        }

    }))
    
    const classes = useStyles()

    return (  

        <Grid className={classes.main}>

            <form noValidate onSubmit={handleSubmit}>
                <Grid container>    
                    <Grid item lg={12}>
                        <Typography variant="h5" className={classes.title}>
                            Recuperar senha
                        </Typography>
                    </Grid>

                    <Grid item lg={12}>
                        <TextField
                            type="email"
                            value={email}
                            name="email"
                            onChange={handleChange}
                            margin="normal"
                            label="Digite seu e-mail" 
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
                        <Button
                            type="submit"
                            variant="contained"
                            color="primary"
                            size="medium"
                            fullWidth
                            className={classes.forgotButton}
                        >
                            Recuperar
                        </Button>
                    </Grid>

                    <Grid item lg={12}>
                        <Typography  className={classes.backLink}>
                            <Link href={LOGIN} onClick={handleRedirectLogin}>
                                Voltar
                            </Link>
                        </Typography>
                    </Grid>
                </Grid>
            </form>

        </Grid>
    );
}
 
export default ForgetPage;