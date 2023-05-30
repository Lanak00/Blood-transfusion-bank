using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.DataAccess.Model;
using BloodTransfusionBank.DataAccess.Repository;
using System.Linq.Expressions;


namespace BloodTransfusionBank.BussinessLogic.Services
{
    public class AppointmentResponseDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }

        public int DonationCenterId { get; set; }
        public Guid? UserId { get; set; }

        public List<CenterAdminstratorResponseDto> Stuff { get; set; }

        public ComplaintResponseForAppointmentDto? Complaint { get; set; }
    }

    public class CenterAdminstratorResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ComplaintResponseForAppointmentDto
    {
        public Guid Id { get; set; }
        public string ReffersTo { get; set; }
        public string Content { get; set; }
        public string? Response { get; set; }
    }


    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<AppointmentResponseDto> GetAppointments(int? donationCenter, Guid? userId, bool? upcoming)
        {
            List<Predicate<Appointment>> conditions = new();

            if (donationCenter != null)
                conditions.Add(x => x.DonationCenterId == donationCenter);
            if (userId != null)
                conditions.Add(x => x.UserId == userId);
            if (upcoming != null)
            {
                Predicate<Appointment> conditionHistory = x => x.DateTime < DateTime.UtcNow;
                Predicate<Appointment> conditionUpcoming = x => x.DateTime > DateTime.UtcNow;
                conditions.Add((bool)upcoming ? conditionUpcoming : conditionHistory);
            }

            Expression<Func<Appointment, bool>> expression = c => conditions.All(pred => pred(c));

            var appointments = _appointmentRepository.GetByCondition(expression).OrderBy(x => x.DateTime);
            return appointments.Select(x => new AppointmentResponseDto()
            {
                Id = x.Id,
                DateTime = x.DateTime,
                Duration = x.Duration,
                UserId = x.UserId,
                Stuff = x.Stuff.Select(s => new CenterAdminstratorResponseDto()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList(),
                DonationCenterId = x.DonationCenterId,
                Complaint = x.Complaint == null ? null : new ComplaintResponseForAppointmentDto() 
                { 
                    Id = x.Complaint.Id,
                    ReffersTo = x.Complaint.ReffersTo.ToString(),
                    Content = x.Complaint.Content,
                    Response = x.Complaint.Response
                }
            });
        }
    }
}
