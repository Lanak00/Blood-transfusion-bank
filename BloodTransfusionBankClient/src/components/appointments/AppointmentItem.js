import React from "react";
import classes from './AppointmentItem.module.css';
import Card from "../ui/Card";

function AppointmentItem(props) {
    return (
    <li className={classes.item}>
    <Card>
    <div className={classes.allcont}>
    <div className={classes.content}>
        <h3>{"Date" + props.date}</h3>
        <h3>{"Time:" + props.time} </h3>
        <h3>{"Duration: " + props.duration + " minutes"}</h3>
        <h3>{"Staff: " + props.medicineStaff}</h3>
    </div>
    <div className={classes.actions}>
        <button> Schedule </button>
    </div>
    </div>
    </Card>
</li>
)
}
export default AppointmentItem;