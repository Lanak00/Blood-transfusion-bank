import {Link} from 'react-router-dom';
import React from 'react';

import classes from './MainNavigation.module.css';

function MainNavigation() {
    return (
    <header className={classes.header}>
        <div className={classes.logo}> Blood Trasfusion Bank</div>
        <nav>
            <ul >
                <li >
                    <Link to = '/'> Donation Centers </Link>
                </li>
                <li >
                    <Link to = '/appointments/:userId'> Appointments </Link>
                </li>
                <li >
                    <Link to = '/complaints/:userId'> Complaints </Link>
                </li>
                <li >
                    <Link to = '/survey'> Survey </Link>
                </li>
                <li >
                    <Link to = '/profile/:userId'> My Profile</Link>
                </li>
            </ul>
        </nav>
    </header>
    );
}
export default MainNavigation;