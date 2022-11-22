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
                <li className={classes.itemheader}>
                    <Link to = '/my-appointments'> Appointments </Link>
                </li>
                <li className={classes.itemheader}>
                    <Link to = '/complaints'> Complaints </Link>
                </li>
                <li className={classes.itemheader}>
                    <Link to = '/survey'> Survey </Link>
                </li>
                <li className={classes.itemheader}>
                    <Link to = '/my-profile'> My Profile</Link>
                </li>
            </ul>
        </nav>
    </header>
    );
}
export default MainNavigation;