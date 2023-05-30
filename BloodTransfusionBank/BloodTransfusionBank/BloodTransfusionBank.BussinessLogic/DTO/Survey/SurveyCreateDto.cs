namespace BloodTransfusionBank.BussinessLogic.DTO.Survey
{
    public class SurveyCreateDto
    {
        public Guid BloodDonorId { get; set; }
        public string BloodType { get; set; }
        public string Alergies { get; set; }
        public string Diseases { get; set; }
    }
}
