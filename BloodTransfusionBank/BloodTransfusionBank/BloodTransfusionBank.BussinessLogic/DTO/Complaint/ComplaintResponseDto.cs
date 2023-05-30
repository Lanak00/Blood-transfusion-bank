    namespace BloodTransfusionBank.BussinessLogic.DTO.Complaint
{
    public class ComplaintResponseDto
    {
        public Guid Id { get; set; }
        public ComplaintReffersTo ReffersTo { get; set; }
        public string Content { get; set; }
        public string? Response { get; set; }
        public Guid BloodDonorId { get; set; }
        public Guid AppointmentId { get; set; }
    }

}
