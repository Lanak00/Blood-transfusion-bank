import React from 'react';
 
function DonationCenterProfilePage(props) {
    return <li>
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
    </li>
}

export default DonationCenterProfilePage;