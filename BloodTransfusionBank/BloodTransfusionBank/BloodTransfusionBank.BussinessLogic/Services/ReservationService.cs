using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.DataAccess.Repository;



namespace BloodTransfusionBank.BussinessLogic.Services
{
    public enum ReservationResult
    {
        Success,
        FailureSurveyNotFilledIn,
        FailureDonorDonatedBloodInPreviousSixMonths,
        FailureUserAlreadyTriedReservation,

    }

    public enum CancelationResult
    {
        Success,
        FailureLessThan24HoursLeft
    }

    public class ReservationService : IReservationService
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly UserRepository _userRepository;
        private readonly SurveyRepository _surveyRepository;


        public ReservationService(
            AppointmentRepository appointmentRepository,
            UserRepository userRepository,
            SurveyRepository surveyRepository)
        {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
            _surveyRepository = surveyRepository;
        }

        public ReservationResult ReserveAppointment(Guid appointmentId, Guid userId)
        {
            var appointment = _appointmentRepository.Get(appointmentId);
            if (appointment == null) throw new Exception();

            var bloodDonor = _userRepository.GetBloodDonor(userId);
            if (bloodDonor == null) throw new Exception();

            // check for filled survey
            var survey = _surveyRepository.Get(userId);
            if (survey == null)
                return ReservationResult.FailureSurveyNotFilledIn;

            // check for last six months activity condition
            var sixMonthsAgo = DateTime.UtcNow.AddMonths(-6);
            var appointmentsInLastSixMonths = _appointmentRepository.GetByCondition(x => x.DateTime > sixMonthsAgo && x.UserId == userId);
            if (appointmentsInLastSixMonths.Any())
                return ReservationResult.FailureDonorDonatedBloodInPreviousSixMonths;

            // check for same user in history list
            var usersInHistory = appointment.UsersReservationHistory.Where(x => x.Id == userId);
            if (usersInHistory.Any())
                return ReservationResult.FailureUserAlreadyTriedReservation;

            appointment.UsersReservationHistory.Add(bloodDonor);
            appointment.UserId = userId;
            _appointmentRepository.Update(appointment);

            return ReservationResult.Success;
        }

        public CancelationResult CancelAppointment(Guid appointmentId)
        {
            var appointment = _appointmentRepository.Get(appointmentId);
            if (appointment == null) throw new Exception();
            
            // > 24h before appointment
            var diff = appointment.DateTime - DateTime.UtcNow;
            if (diff.TotalDays < 1)
                return CancelationResult.FailureLessThan24HoursLeft;

            appointment.UserId = null;
            _appointmentRepository.Update(appointment);

            return CancelationResult.Success;
        }
    }
}
