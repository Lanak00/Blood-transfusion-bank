using BloodTransfusionBank.BussinessLogic.DTO;
using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.BussinessLogic.Mappers;
using BloodTransfusionBank.DataAccess.Model;
using BloodTransfusionBank.DataAccess.Repository;
using CarpenterWorkshop.BusinessLogic.Services.Auth.PasswordSecurity;

namespace BloodTransfusionBank.BussinessLogic.Services.Auth
{
    public enum LoginResult
    {
        Success,
        UserDoesNotExists,
        UserNotValidated,
        PasswordsDoNotMatch
    }

    public enum RegisterResult
    {
        Success,
        UserAlreadyExists
    }

    public enum ValidationResult
    {
        Success,
        UserDoesNotExists
    }

    public enum UserRole
    {
        Administrator,
        CenterAdministrator,
        BloodDonor,
        Unknown
    }

    public class Login
    {
        public LoginResult LoginResult { get; set; }
        public UserRole UserRole { get; set; }
        public Guid UserId { get; set; }
    }

    public class Register
    {
        public RegisterResult RegisterResult { get; set; }
        public Guid Id { get; set; }
    }

    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Register RegisterBloodDonor(BloodDonorRegisterDto user)
        {
            var usr = _userRepository.GetByCondition(x => x.Email == user.Email).FirstOrDefault();
            if (usr != null) return new Register() { RegisterResult = RegisterResult.UserAlreadyExists, Id = Guid.Empty };

            var bloodDonor = new BloodDonor()
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = PasswordStorage.CreateHash(user.Password),
                Email = user.Email,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                Gender = UserMapper.MapGender(user.Gender),
                Occupation = UserMapper.MapOccupation(user.Occupation),
                IsValidated = false
            };

            var id = _userRepository.AddBloodDonor(bloodDonor);
            return new Register() { RegisterResult = RegisterResult.Success, Id = id };
        }

        public Login Login(string email, string password)
        {
            var user = _userRepository.GetByCondition(x => x.Email == email).FirstOrDefault();
            if (user == null)
                return new Login()
                { 
                    LoginResult = LoginResult.UserDoesNotExists,
                    UserRole = UserRole.Unknown,
                    UserId = Guid.Empty
                };

            /*if (!user.IsValidated)
                return new Login()
                {
                    LoginResult = LoginResult.UserNotValidated,
                    UserRole = UserRole.Unknown,
                    UserId = Guid.Empty
                };*/

            bool isPasswordValid = PasswordStorage.VerifyPassword(password, user.Password);
            if (!isPasswordValid)
                return new Login()
                {
                    LoginResult = LoginResult.PasswordsDoNotMatch,
                    UserRole = UserRole.Unknown,
                    UserId = Guid.Empty
                };

            return new Login() 
            {
                LoginResult = LoginResult.Success,
                UserRole = UserMapper.MapUserRole(user.Role),
                UserId = user.Id
            };
        }


        public ValidationResult Validate(Guid id)
        {
            var user = _userRepository.Get(id);
            if (user == null) return ValidationResult.UserDoesNotExists;

            user.IsValidated = true;
            _userRepository.Update(user);
            return ValidationResult.Success;
        }
    }
}
