import {Link} from 'react-router-dom';
import React from 'react';

import classes from './AppointmentsMenu.module.css';

function AppointmentsMenu() {
    return (
    <header className={classes.header}>
        <nav>
            <ul >
                <li >
                    <Link to = '/appointments/:userId'> Upcoming </Link>
                </li>
                <li >
                    <Link to = '/appointments/:userId/history'> History </Link>
                </li>
            </ul>
        </nav>
    </header>
    );
}
export default AppointmentsMenu;