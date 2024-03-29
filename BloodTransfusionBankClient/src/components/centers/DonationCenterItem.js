import HoverCard from '../ui/HoverCard';
import classes from './DonationCenterItem.module.css';
import React from 'react';
import { useHistory } from "react-router-dom";

function DonationCenterItem(props) {
 
    const navigate = useHistory();

    const navigateToCenterDetails = async () => {
        navigate.push("/center-profile/" + props.id, { id: props.id });
        console.log(props.id);
        console.log(props.address);
    }

    return <li className={classes.item}>
     <button onClick={navigateToCenterDetails}>
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
     </button>
    </li>
}
export default DonationCenterItem;