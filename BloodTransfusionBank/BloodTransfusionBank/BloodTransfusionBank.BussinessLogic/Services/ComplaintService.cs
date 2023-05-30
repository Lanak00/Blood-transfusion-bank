using BloodTransfusionBank.BussinessLogic.DTO.Complaint;
using BloodTransfusionBank.BussinessLogic.Extensions;
using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.DataAccess.Model;
using BloodTransfusionBank.DataAccess.Repository;
using System.Linq.Expressions;


namespace BloodTransfusionBank.BussinessLogic.Services
{
    public enum ComplaintCreationResult
    {
        Success,
        FailedAppointmentAlreadyHasComplaint,
        FailedAppointmentInFuture,
        FailedInvalidBloodDonorProvided,
        FailedAppointmentNotReserved
    }

    public class ComplaintCreationResponse
    {
        public ComplaintCreationResult Result { get; set; }
        public Guid ComplaintId { get; set; } = Guid.Empty;
    }

    public class ComplaintService : IComplaintService
    {
        private readonly ComplaintRepository _complaintRepository;
        private readonly UserRepository _userRepository;
        private readonly AppointmentRepository _appointmentRepository;

        public ComplaintService(
            ComplaintRepository complaintRepository,
            UserRepository userRepository,
            AppointmentRepository appointmentRepository)
        {
            _complaintRepository = complaintRepository;
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
        }

        public ComplaintCreationResponse CreateComplaint(ComplaintCreateDto complaintDto)
        {
            var appointment = _appointmentRepository.Get(complaintDto.AppointmentId);
            if (appointment == null) throw new Exception();

            var bloodDonor = _userRepository.Get(complaintDto.BloodDonorId);
            if (bloodDonor == null) throw new Exception();

            if (appointment.Complaint != null)
                return new ComplaintCreationResponse() { Result = ComplaintCreationResult.FailedAppointmentAlreadyHasComplaint };

            if (appointment.UserId == null)
                return new ComplaintCreationResponse() { Result = ComplaintCreationResult.FailedAppointmentNotReserved };

            if (appointment.UserId != bloodDonor.Id)
                return new ComplaintCreationResponse() { Result = ComplaintCreationResult.FailedInvalidBloodDonorProvided }; 

            var appointmentDateTimeEnd = appointment.DateTime.AddMinutes(appointment.Duration);
            if (appointmentDateTimeEnd < DateTime.UtcNow)
                return new ComplaintCreationResponse() { Result = ComplaintCreationResult.FailedAppointmentInFuture };

            var complaint = new Complaint()
            {
                Id = Guid.NewGuid(),
                ReffersTo = MapComplaintReffersToFromDAToBL(complaintDto.ReffersTo),
                AppointmentId = complaintDto.AppointmentId,
                BloodDonorId = complaintDto.BloodDonorId,
                Content = complaintDto.Content,
                Response = null
            };
            var complaintId = _complaintRepository.Add(complaint);

            return new ComplaintCreationResponse()
            {
                Result = ComplaintCreationResult.Success,
                ComplaintId = complaintId
            };
        }

        public IEnumerable<ComplaintResponseDto> GetComplaints(int? donationCenterId, Guid? bloodDonorId)
        {
            List<Predicate<Complaint>> conditions = new();

            if (donationCenterId != null)
                conditions.Add(x => x.Appointment.DonationCenterId == donationCenterId);
            if (bloodDonorId != null)
                conditions.Add(x => x.BloodDonorId == bloodDonorId);
            
            Expression<Func<Complaint, bool>> expression = c => conditions.All(pred => pred(c));
            var complaints = _complaintRepository.GetByCondition(expression);
            
            return complaints.Select(x => new ComplaintResponseDto()
            {
                Id = x.Id,
                BloodDonorId = x.BloodDonorId,
                AppointmentId = x.AppointmentId,
                Content = x.Content,
                ReffersTo = MapComplaintReffersToFromBLToDA(x.ReffersTo),
                Response = x.Response
            });
        }

        private DataAccess.Model.ComplaintReffersTo MapComplaintReffersToFromDAToBL(DTO.Complaint.ComplaintReffersTo complaintReffersTo)
        {
            switch (complaintReffersTo)
            {
                case DTO.Complaint.ComplaintReffersTo.DonationCenter: return DataAccess.Model.ComplaintReffersTo.DonationCenter;
                case DTO.Complaint.ComplaintReffersTo.Staff: return DataAccess.Model.ComplaintReffersTo.Staff;
                default: throw new NotImplementedException();
            }
        }

        private DTO.Complaint.ComplaintReffersTo MapComplaintReffersToFromBLToDA(DataAccess.Model.ComplaintReffersTo complaintReffersTo)
        {
            switch (complaintReffersTo)
            {
                case DataAccess.Model.ComplaintReffersTo.DonationCenter: return DTO.Complaint.ComplaintReffersTo.DonationCenter;
                case DataAccess.Model.ComplaintReffersTo.Staff: return DTO.Complaint.ComplaintReffersTo.Staff;
                default: throw new NotImplementedException();
            }
        }
    }
}
