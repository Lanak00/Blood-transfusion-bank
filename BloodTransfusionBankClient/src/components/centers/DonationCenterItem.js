import HoverCard from '../ui/HoverCard';
import classes from './DonationCenterItem.module.css';
import React from 'react';
import {Link} from 'react-router-dom';

function DonationCenterItem(props) {
    return <li className={classes.item}>
        <Link to = {`/center-profile/${props.id}/appointments`}>
        <HoverCard>
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
        </HoverCard>
        </Link>
       
    </li>
}
export default DonationCenterItem;