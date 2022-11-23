import Card from '../ui/Card'
import classes from './DonationCenterItem.module.css';
import React from 'react';

function DonationCenterItem(props) {
    return <li className={classes.item}>
        <Card>
        <div className={classes.allcont}>
        <div className={classes.image}>
            <img src = {props.image} alt={props.title}/>
        </div>
        <div className={classes.content}>
            <h3>{props.name}</h3>
            <address>{props.address + " " + props.city} </address>
            <p>{props.description}</p>
        </div>
        </div>
        </Card>
    </li>
}
export default DonationCenterItem;