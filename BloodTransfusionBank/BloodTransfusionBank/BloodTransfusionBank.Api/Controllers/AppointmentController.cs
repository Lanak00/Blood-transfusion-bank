using Microsoft.AspNetCore.Mvc;
using BloodTransfusionBank.BussinessLogic.Interfaces;


namespace BloodTransfusionBank.Api.Controllers
{
    [ApiController]
    [Route("appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [HttpGet]
        public ActionResult GetAll(int? donationCenter, Guid? userId, bool? upcoming)
        {
            var donationCenters = _appointmentService.GetAppointments(donationCenter, userId, upcoming);
            return Ok(donationCenters);
        }
    }
}
