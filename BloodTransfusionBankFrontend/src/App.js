import React from 'react';
import {Route, Switch} from 'react-router-dom';
import AllDonationCentersPage from './pages/DonationCenters';
import AllDonationCenterAppointments from './pages/CenterAppointments';
import DonationCenterProfilePage from './pages/DonationCenterProfile';
import MyAppointmentsPage from './pages/MyAppointments';
import MyProfilePage from './pages/MyProfile';
import SurveyPage from './pages/Survey';
import AllComplaintsPage from './pages/Complaints';

import MainNavigation from './components/layout/MainNavigation';


function App() {
   return ( 
   <div>
    <MainNavigation/>
    <Switch>
    <Route path='/' exact>
      <AllDonationCentersPage/>
    </Route>
    <Route path='/temp-center-profile'>
      <DonationCenterProfilePage/>
    </Route>
    <Route path='/temp-center-appointments'>
      <AllDonationCenterAppointments/>
    </Route>
    <Route path='/my-appointments'>
      <MyAppointmentsPage/>
    </Route>
    <Route path='/my-profile'>
      <MyProfilePage/>
    </Route>
    <Route path='/survey'>
      <SurveyPage/>
    </Route>
    <Route path='/complaints'>
      <AllComplaintsPage/>
    </Route>
    </Switch>
   </div>
   );
}

export default App;
