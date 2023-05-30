namespace BloodTransfusionBank.BussinessLogic.DTO.Complaint
{
    public class ComplaintCreateDto
    {
        public ComplaintReffersTo ReffersTo { get; set; }
        public string Content { get; set; }
        public Guid BloodDonorId { get; set; }
        public Guid AppointmentId { get; set; }
    }
}
