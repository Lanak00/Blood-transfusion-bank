import React from "react";
import DonationCenterItem from "./DonationCenterItem";
import classes from './DonationCenterList.module.css';

function DonationCenterList(props) {
return (
 <ul className = {classes.list}>
     {props.centers.map(center=> <DonationCenterItem
        key = {center.id}
        id = {center.id}
        name = {center.name}
        image = {center.image}
        address = {center.address}
        city = {center.city}
        description = {center.description}      
     />)} 
</ul>
)
}
export default DonationCenterList;