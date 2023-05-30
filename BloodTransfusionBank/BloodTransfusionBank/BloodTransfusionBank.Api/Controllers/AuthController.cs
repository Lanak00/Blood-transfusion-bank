using BloodTransfusionBank.BussinessLogic.DTO;
using BloodTransfusionBank.BussinessLogic.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BloodTransfusionBank.BussinessLogic.Interfaces;


namespace BloodTransfusionBank.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<Guid> Register(BloodDonorRegisterDto user)
        {
            var result = _authService.RegisterBloodDonor(user);
            if (result.RegisterResult == RegisterResult.Success)
                return Created("auth/register/", new { id = result.Id.ToString() });
            
            return BadRequest("User already exists");
        }

        [HttpPost("login")]
        public ActionResult<Guid> Login(LoginCredentials loginCredentials)
        {
            var result = _authService.Login(loginCredentials.Email, loginCredentials.Password);
            if (result.LoginResult == LoginResult.UserDoesNotExists || result.LoginResult == LoginResult.PasswordsDoNotMatch)
                return Unauthorized();
            if (result.LoginResult == LoginResult.UserNotValidated)
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "User is not validated" });
              
            var token = GenerateJSONWebToken(result.UserId.ToString());

            return Ok(new { token = token, role = result.UserRole.ToString(), id = result.UserId.ToString() });
        }

        private string GenerateJSONWebToken(string id)
        {
            var key = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, id)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }


        [HttpPost("validate")]
        public ActionResult<Guid> Validate(Guid userId)
        {
            var result = _authService.Validate(userId);
            if (result == ValidationResult.UserDoesNotExists)
                return BadRequest("Invalid Id");

            return NoContent();
        }
    }

    public class LoginCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
