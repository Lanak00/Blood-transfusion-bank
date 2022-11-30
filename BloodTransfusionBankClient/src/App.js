import React from 'react';
import {Route, Switch} from 'react-router-dom';
import AllDonationCentersPage from './pages/DonationCenters';
import AllDonationCenterAppointments from './pages/CenterAppointments';
import DonationCenterProfilePage from './pages/DonationCenterProfile';
import MyAppointmentsPage from './pages/MyAppointments';
import MyProfilePage from './pages/MyProfile';
import SurveyPage from './pages/Survey';
import AllComplaintsPage from './pages/Complaints';

import Layout from './components/layout/Layout';


function App() {
   return ( 
   <Layout>
    <Switch>
    <Route path='/' exact>
      <AllDonationCentersPage/>
    </Route>
    <Route path='/center-profile/:id/'>
      <DonationCenterProfilePage/>
    </Route>
    <Route path='/center-profile/:id/appointments'>
      <AllDonationCenterAppointments/>
    </Route>
    <Route path='/appointments/:userid/'>
      <MyAppointmentsPage/>
    </Route>
    <Route path='/profile/:userId/'>
      <MyProfilePage/>
    </Route>
    <Route path='/survey'>
      <SurveyPage/>
    </Route>
    <Route path='/complaints/:userId'>
      <AllComplaintsPage/>
    </Route>
    </Switch>
   </Layout>
   );
}

export default App;
