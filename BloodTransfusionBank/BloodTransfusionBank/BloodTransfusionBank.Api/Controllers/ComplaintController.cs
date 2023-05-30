using Microsoft.AspNetCore.Mvc;
using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.BussinessLogic.Services;


namespace BloodTransfusionBank.Api.Controllers
{
    [ApiController]
    [Route("complaints")]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpGet]
        public ActionResult GetAll(int? donationCenterId, Guid? bloodDonorId)
        {
            var complaints = _complaintService.GetComplaints(donationCenterId, bloodDonorId);
            return Ok(complaints);
        }

        [HttpPost]
        public ActionResult Create(BussinessLogic.DTO.Complaint.ComplaintCreateDto complaint)
        {
            var response = _complaintService.CreateComplaint(complaint);
            if (response.Result == ComplaintCreationResult.FailedAppointmentInFuture)
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "Appointment yet to happen" });
            if (response.Result == ComplaintCreationResult.FailedAppointmentNotReserved)
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "Appointment is not reserved" });
            if (response.Result == ComplaintCreationResult.FailedInvalidBloodDonorProvided)
                return BadRequest("Invalid blood donor is provided");

            return NoContent();
        }
    }
}
