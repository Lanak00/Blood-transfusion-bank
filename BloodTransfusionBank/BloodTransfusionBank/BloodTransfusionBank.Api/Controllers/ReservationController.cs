using Microsoft.AspNetCore.Mvc;
using BloodTransfusionBank.BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BloodTransfusionBank.Api.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [HttpGet("reserve")]
        public ActionResult Reserve([BindRequired]Guid appointmentId, [BindRequired]Guid bloodDonorId)
        {
            var reservationResult = _reservationService.ReserveAppointment(appointmentId, bloodDonorId);
            if (reservationResult == BussinessLogic.Services.ReservationResult.FailureSurveyNotFilledIn)
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "Blood donor hasn't filled his survey" });
            if (reservationResult == BussinessLogic.Services.ReservationResult.FailureDonorDonatedBloodInPreviousSixMonths)
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "Blood donor has donated blood in previus 6 months" });
            if (reservationResult == BussinessLogic.Services.ReservationResult.FailureUserAlreadyTriedReservation)
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "Blood donor alredy had this reservation" });
            
            return Ok("Success");
        }

        [HttpGet("cancel")]
        public ActionResult Cancel([BindRequired]Guid appointmentId)
        {
            var cancelationResult = _reservationService.CancelAppointment(appointmentId);
            if (cancelationResult == BussinessLogic.Services.CancelationResult.FailureLessThan24HoursLeft)
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "Less than 24 hours left" });

            return Ok("Success");
        }
    }
}

