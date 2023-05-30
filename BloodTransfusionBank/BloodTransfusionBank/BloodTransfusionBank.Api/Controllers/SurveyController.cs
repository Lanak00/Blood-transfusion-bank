using Microsoft.AspNetCore.Mvc;
using BloodTransfusionBank.BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BloodTransfusionBank.Api.Controllers
{
    [ApiController]
    [Route("surveys")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public ActionResult Get([BindRequired] Guid bloodDonorId)
        {
            var complaint = _surveyService.GetSurvey(bloodDonorId);
            return Ok(complaint);
        }


        [HttpPost]

        public ActionResult Create(BussinessLogic.DTO.Survey.SurveyCreateDto survey)
        {
            _surveyService.CreateSurvey(survey);
            return NoContent();
        }
    }
}