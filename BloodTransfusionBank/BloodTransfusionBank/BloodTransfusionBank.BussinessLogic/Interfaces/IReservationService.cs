using BloodTransfusionBank.BussinessLogic.Services;



namespace BloodTransfusionBank.BussinessLogic.Interfaces
{
    public interface IReservationService
    {
        ReservationResult ReserveAppointment(Guid appointmentId, Guid userId);
        CancelationResult CancelAppointment(Guid appointmentId);
    }
}
