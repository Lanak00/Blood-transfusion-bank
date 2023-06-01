import React from 'react';
import { useParams } from 'react-router-dom';

function DonationCenterProfilePage(props) {

    const params = useParams();

    console.log(params);
    return <li>
        <div>
            <div>
                <h1>{props.id}</h1>
            </div>
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
