namespace BloodTransfusionBank.DataAccess.Model
{
    public class BloodDonor : User
    {
        public BloodDonor() => this.Role = UserRole.BloodDonor;

        public int Penalities { get; set; } = 0;
        public List<Appointment> ReservationHistory { get; set; } = new List<Appointment>();

        public Survey Survey { get; set; }

        public IEnumerable<Complaint> Complaints { get; set; }
    }
}
