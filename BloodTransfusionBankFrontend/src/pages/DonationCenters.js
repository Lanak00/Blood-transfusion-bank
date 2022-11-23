import React from 'react';
import DonationCenterList from '../components/centers/DonationCenterList'

const DUMMY_DATA = [
    {
        id : 1,
        name: 'Dom Zdravlja Mladen Stojanovic',
        address: 'Bulevar Oslobodjenja 2',
        city: 'Backa Palanka',
        rating: 4.3,
        image: 'https://upload.wikimedia.org/wikipedia/commons/3/3d/Hartford_Hospital_main_entrance.JPG',
        description: 'Dom zdravlja Mladen Stojanovic sprovodi mere primarne zdravstvene zaštite u opštini Backa Palanka. Ustanova danas predstavlja zaokruženu radnu celinu u prostornom, kadrovskom i tehničko-tehnološkom sadržaju. U potpunosti je obezbeđena kvalitetna zdravstvenu zaštita u službama centralnog objekta u gradu i u zdravstvenim stanicama i ambulantama na teritoriji naseljnih mesta.'
    },
    {
        id : 2,
        name: 'Dom Zdravlja Mitar Miric',
        address: 'Kosovska 18',
        city: 'Leskovac',
        rating: 4.9,
        image: 'https://i0.wp.com/ctnewsjunkie.com/wp-content/uploads/2020/12/UConn_Health_Center_wikipedia_720x540_720_540_99_sha-100.jpg?fit=720%2C540&ssl=1',
        description: 'Mitrov dom zdravlja u Leskovcu sprovodi mere primarne zdravstvene zaštite u opštini Backa Palanka. Ustanova danas predstavlja zaokruženu radnu celinu u prostornom, kadrovskom i tehničko-tehnološkom sadržaju. U potpunosti je obezbeđena kvalitetna zdravstvenu zaštita u službama centralnog objekta u gradu i u zdravstvenim stanicama i ambulantama na teritoriji naseljnih mesta. '
    },
    {
        id : 3,
        name: 'Dom Zdravlja Mladen Stojanovic',
        address: 'Blagoja Parovica 81',
        city: 'Backa Palanka',
        rating: 4.3,
        image: 'https://upload.wikimedia.org/wikipedia/commons/a/a2/Biandintz_eta_zaldiak_-_modified2.jpg',
        description: 'Ovo je opis treceg centra za transfuziju krvi koji treba da bude malo duzi sprovodi mere primarne zdravstvene zaštite u opštini Backa Palanka. Ustanova danas predstavlja zaokruženu radnu celinu u prostornom, kadrovskom i tehničko-tehnološkom sadržaju. U potpunosti je obezbeđena kvalitetna zdravstvenu zaštita u službama centralnog objekta u gradu i u zdravstvenim stanicama i ambulantama na teritoriji naseljnih mesta.'
    },
    {
        id : 4,
        name: 'Dom Zdravlja Mitar Miric',
        address: 'Kosovska 18',
        city: 'Leskovac',
        rating: 4.9,
        image: 'https://upload.wikimedia.org/wikipedia/commons/3/30/Jubilee_and_Munin%2C_Ravens%2C_Tower_of_London_2016-04-30.jpg',
        description: 'dom zdravlja u Backoj palanci sprovodi mere primarne zdravstvene zaštite u opštini Backa Palanka. Ustanova danas predstavlja zaokruženu radnu celinu u prostornom, kadrovskom i tehničko-tehnološkom sadržaju. U potpunosti je obezbeđena kvalitetna zdravstvenu zaštita u službama centralnog objekta u gradu i u zdravstvenim stanicama i ambulantama na teritoriji naseljnih mesta. '
    }
]

function AllDonationCentersPage() {
    return (
        <section>
            <DonationCenterList centers = {DUMMY_DATA}/>
        </section>
    );
}
export default AllDonationCentersPage;