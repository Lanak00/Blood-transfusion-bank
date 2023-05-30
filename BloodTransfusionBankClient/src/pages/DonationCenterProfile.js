import React from 'react';
import { useNavigation, useNavigationParam } from '@react-navigation/native';

function DonationCenterProfilePage() {
    
    console.log(props)
    const props = useNavigationParam('props');
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