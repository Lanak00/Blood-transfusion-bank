using BloodTransfusionBank.BussinessLogic.DTO.Survey;


namespace BloodTransfusionBank.BussinessLogic.Interfaces
{
    public interface ISurveyService
    {
        void CreateSurvey(SurveyCreateDto surveyDto);
        public SurveyRepsonseDto GetSurvey(Guid bloodDonorId);
    }
}
