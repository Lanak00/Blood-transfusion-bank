using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodTransfusionBankShared
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int DonationCenterId { get; set; }

        /* + lista CenterAdministratora (angazovano osoblje) */
    }
}
