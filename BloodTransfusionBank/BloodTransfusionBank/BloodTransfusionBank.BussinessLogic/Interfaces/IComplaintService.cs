using BloodTransfusionBank.BussinessLogic.DTO.Complaint;
using BloodTransfusionBank.BussinessLogic.Services;


namespace BloodTransfusionBank.BussinessLogic.Interfaces
{
    public interface IComplaintService
    {
        ComplaintCreationResponse CreateComplaint(ComplaintCreateDto complaintDto);
        IEnumerable<ComplaintResponseDto> GetComplaints(int? donationCenterId, Guid? bloodDonorId);
    }
}
