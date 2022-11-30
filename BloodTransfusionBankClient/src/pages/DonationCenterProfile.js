import React from 'react';
import Card from '../components/ui/Card';
 
function DonationCenterProfilePage(props) {
    return <li>
        <Card>
        <div>
        <div>
            <img src = {props.image} alt={props.title}/>
        </div>
        <div>
            <h3>{props.name}</h3>
            <address>{props.address + " " + props.city} </address>
            <p>{props.description}</p>
        </div>
        </div>
        </Card>
    </li>
}

export default DonationCenterProfilePage;