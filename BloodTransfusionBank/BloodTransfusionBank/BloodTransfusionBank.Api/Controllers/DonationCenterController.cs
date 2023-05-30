using Microsoft.AspNetCore.Mvc;
using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.BussinessLogic.Services;


namespace BloodTransfusionBank.Api.Controllers
{
    [ApiController]
    [Route("donationCenters")]
    public class DonationCenterController : ControllerBase
    {
        private readonly IDonationCenterService _donationCenterService;

        public DonationCenterController(IDonationCenterService donationCenterService)
        {
            _donationCenterService = donationCenterService;
        }

        [HttpGet]
        public ActionResult GetAll(string? name, string? city, SortDonationCentersBy? sortBy, SortOrder? sortOrder)
        {
            var donationCenters = _donationCenterService.GetDonationCenters(name, city, sortBy, sortOrder);
            return Ok(donationCenters);
        }
    }
}
