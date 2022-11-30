using System;
using System.Collections.Generic;

namespace BloodTransfusionBankShared
{
    public class DonationCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description{ get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
