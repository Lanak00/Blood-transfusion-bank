using BloodTransfusionBank.BussinessLogic.DTO.Survey;
using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.DataAccess.Model;
using BloodTransfusionBank.DataAccess.Repository;


namespace BloodTransfusionBank.BussinessLogic.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly SurveyRepository _surveyRepository;
        public SurveyService(SurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public void CreateSurvey(SurveyCreateDto surveyDto)
        {
            var survey = new Survey()
            {
                BloodDonorId = surveyDto.BloodDonorId,
                Alergies = surveyDto.Alergies,
                BloodType = surveyDto.BloodType,
                Diseases = surveyDto.Diseases
            };
            _surveyRepository.Add(survey);
        }

        public SurveyRepsonseDto GetSurvey(Guid bloodDonorId)
        {
            var survey = _surveyRepository.Get(bloodDonorId);
            return new SurveyRepsonseDto()
            {
                Alergies = survey.Alergies,
                BloodDonorId = survey.BloodDonorId,
                BloodType = survey.BloodType,
                Diseases = survey.Diseases
            };
        }
    }
}
