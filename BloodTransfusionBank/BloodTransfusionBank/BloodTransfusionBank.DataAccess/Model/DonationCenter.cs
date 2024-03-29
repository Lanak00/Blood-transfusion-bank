﻿namespace BloodTransfusionBank.DataAccess.Model
{
    public class DonationCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public byte[] Image { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
