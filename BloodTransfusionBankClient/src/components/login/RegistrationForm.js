import React from "react";
import classes from './RegistrationForm.module.css';
import Card from "../ui/Card";

function RegistrationForm(props) {
    return (
          <div className={classes.container}>
               <Card>
                    <form className={classes.form}>
                         <h1>Create account</h1>
                         <div>
                              <div className = {classes.items}>
                                   <label >Username </label>
                                   <input  type="text" name="uname" required />
                              </div>
                              <div className = {classes.items} >
                                   <label>Password </label>
                                   <input type="password" name="pass" required />
                              </div>
                              <div className = {classes.items} >
                                   <label> Repeat Password </label>
                                   <input  type="password" name="pass" required />
                              </div>
                              <div className = {classes.items}  >
                                   <label > First Name </label>
                                   <input type="text" name="fname" required />
                              </div>
                              <div className = {classes.items}  >
                                   <label > Last Name </label>
                                   <input type="text" name="lname" required />
                              </div>
                              <div  className = {classes.items} >
                                   <label > Date of Birth</label>
                                   <input type="date" name="dobirth" required/>
                              </div>
                              <div className = {classes.items}  >
                                   <label > Address </label>
                                   <input type="text" name="pass" required />
                              </div>
                              <div  className = {classes.items} >
                                   <label > City </label>
                                   <input type="text" name="pass" required />
                              </div>
                              <div className = {classes.items}  >
                                   <label > Phone number</label>
                                   <input type="text" name="pass" required />
                              </div>
                              <div className = {classes.items} >
                                   <label className="classes.labels"> Gender</label>
                                   <input type="radio" value="Male" name="gender" /> Male
                                   <input type="radio" value="Female" name="gender" /> Female
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
export default RegistrationForm;