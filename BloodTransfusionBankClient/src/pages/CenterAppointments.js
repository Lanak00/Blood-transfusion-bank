import React from 'react';
import AppointmentItemList from '../components/appointments/AppointmentItemList';



const DUMMY_DATA = [
    {
        id : 1,
        date: '25.12.2022',
        time: '10:10',
        duration: 20,
        medicineStaff: 'Lana',
    },
    {
        id : 2,
        date: '25.12.2022',
        time: '10:10',
        duration: 20,
        medicineStaff: 'Lana',
    },
    {
        id : 3,
        date: '25.12.2022',
        time: '10:10',
        duration: 20,
        medicineStaff: 'Lana',
    },
    {
        id : 4,
        date: '25.12.2022',
        time: '10:10',
        duration: 20,
        medicineStaff: 'Lana',
    }
]



function AllDonationCenterAppointments() {

    return (
    <section>
        <AppointmentItemList appointments = {DUMMY_DATA} ></AppointmentItemList>
    </section>
)
}

export default AllDonationCenterAppointments;