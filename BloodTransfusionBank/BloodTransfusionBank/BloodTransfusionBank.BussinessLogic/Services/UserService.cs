using BloodTransfusionBank.BussinessLogic.DTO;
using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.DataAccess.Repository;


namespace BloodTransfusionBank.BussinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepoistory; 

        public UserService(UserRepository userRepository)
        {
            _userRepoistory = userRepository;
        }

        public BloodDonorResponseDto GetBloodDonor(Guid bloodDonorId)
        {
            var bloodDonor = _userRepoistory.GetBloodDonor(bloodDonorId);
            return new BloodDonorResponseDto()
            {
                FirstName = bloodDonor.FirstName,
                LastName = bloodDonor.LastName,
                Email = bloodDonor.Email,
                Address = bloodDonor.Address,
                City = bloodDonor.City,
                Country = bloodDonor.Country,
                Gender = bloodDonor.Gender.ToString(),
                Occupation = bloodDonor.Occupation.ToString()
            };
        }
    }
}
