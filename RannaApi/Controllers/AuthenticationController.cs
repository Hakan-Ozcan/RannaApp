using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RannaApi.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ICustomerService _customerService;

        public AuthenticationController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public static bool VerifyPassword(string password, string storedPassword)
        {
    
            return password == storedPassword;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
      
            var user = await _customerService.GetUserByUsernameAsync(username);
            if (user == null)
            {
       
                return new LoginResponse { result = false, token = null };
            }

 
            bool isPasswordValid = VerifyPassword(password, user.password);
            if (!isPasswordValid)
            {
            
                return new LoginResponse { result = false, token = null };
            }

      
            var token = GenerateJwtToken(user.id);

     
            return new LoginResponse { result = true, token = token };
        }

        private string GenerateJwtToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-secret-key-12345678901234567890123456789012");
            var securityKey = new SymmetricSecurityKey(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1), // Token'ın süresi
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
