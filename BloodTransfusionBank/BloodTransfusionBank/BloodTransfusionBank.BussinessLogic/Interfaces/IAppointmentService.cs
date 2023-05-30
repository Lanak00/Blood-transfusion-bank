using BloodTransfusionBank.BussinessLogic.Services;


namespace BloodTransfusionBank.BussinessLogic.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentResponseDto> GetAppointments(int? donationCenter, Guid? userId, bool? upcoming);
    }
}
