using BloodTransfusionBank.BussinessLogic.DTO;
using BloodTransfusionBank.BussinessLogic.Services.Auth;


namespace BloodTransfusionBank.BussinessLogic.Interfaces
{
    public interface IAuthService
    {
        public Register RegisterBloodDonor(BloodDonorRegisterDto user);
        public Login Login(string email, string password);
        public ValidationResult Validate(Guid id);
    }
}
