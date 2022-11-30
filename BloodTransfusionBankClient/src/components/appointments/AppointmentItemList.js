import React from "react";
import AppointmentItem from "./AppointmentItem";
import classes from './AppointmentItemList.module.css';

function AppointmentItemList(props) {
return (
 <ul className = {classes.list}>
     {props.appointments.map(appointment=> <AppointmentItem
        key = {appointment.id}
        id = {appointment.id}
        date = {appointment.date}
        time = {appointment.time}
        duration = {appointment.duration}
        medicineStaff = {appointment.medicineStaff}       
     />)} 
</ul>
)
}
export default AppointmentItemList;