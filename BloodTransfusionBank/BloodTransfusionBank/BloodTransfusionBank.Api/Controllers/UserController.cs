using Microsoft.AspNetCore.Mvc;
using BloodTransfusionBank.BussinessLogic.Interfaces;


namespace BloodTransfusionBank.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("bloodDonors/{id}")]
        public ActionResult Get(Guid id)
        {
            var bloodDonor = _userService.GetBloodDonor(id);
            return Ok(bloodDonor);
        }
    }
}