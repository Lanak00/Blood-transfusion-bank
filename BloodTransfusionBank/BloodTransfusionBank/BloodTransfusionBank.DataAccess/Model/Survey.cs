namespace BloodTransfusionBank.DataAccess.Model
{
    public class Survey
    {
        public Guid BloodDonorId { get; set; }
        public BloodDonor BloodDonor { get; set; }

        public string BloodType { get; set; }
        public string Alergies { get; set; }
        public string Diseases { get; set; }
    }
}
