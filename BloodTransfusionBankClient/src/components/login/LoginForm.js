import React, { useState } from 'react';
import classes from './LoginForm.module.css';
import Card from "../ui/Card";
import { Link } from "react-router-dom/cjs/react-router-dom.min";


function LoginForm(props) {
    const [username, setUsername] = useState(0);  

    return (
        <div className={classes.container}>
            <Card>
                <form className={classes.form} >
                    <h1>Login</h1>
                    <div className={classes.inputs}>
                        <div className = {classes.items} >
                            <label className="classes.labels">Username </label>
                            <input type="text" onChange={() => setUsername(username)} name="uname" required />
                        </div>
                        <div className = {classes.items}>
                            <label className="classes.labels">Password </label>
                            <input type="password" name="pass" required />
                        </div>
                        <div className = {classes.items}>
                            <label>You don't have an account?</label> 
                            <Link className = {classes.linkto} to = '/register'> Register here</Link>
                        </div>
                        <div className={classes.button}>
                            <input type="submit"/>
                        </div>
                    </div>
                </form>
            </Card>
        </div>
)
}
export default LoginForm;