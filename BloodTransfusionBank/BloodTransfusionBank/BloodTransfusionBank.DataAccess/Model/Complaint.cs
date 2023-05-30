namespace BloodTransfusionBank.DataAccess.Model
{
    public enum ComplaintReffersTo
    {
        DonationCenter,
        Staff
    }

    public class Complaint
    {
        public Guid Id { get; set; }
        public ComplaintReffersTo ReffersTo { get; set; }
        public string Content { get; set; }
        public string? Response { get; set; }

        public Guid BloodDonorId { get; set; }
        public BloodDonor BloodDonor { get; set; }

        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
