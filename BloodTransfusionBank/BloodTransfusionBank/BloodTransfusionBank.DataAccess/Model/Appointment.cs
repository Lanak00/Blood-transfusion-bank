namespace BloodTransfusionBank.DataAccess.Model
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }


        public int DonationCenterId { get; set; }
        public DonationCenter DonationCenter { get; set; }

        public List<CenterAdministrator> Stuff { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }


        public List<BloodDonor> UsersReservationHistory { get; set; } = new List<BloodDonor>();

        public Complaint? Complaint { get; set; }
    }
}
