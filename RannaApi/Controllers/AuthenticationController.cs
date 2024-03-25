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

        public LoginResponse LoginAsync(string username, string password)
        {
            // Kullanıcı doğrulaması yap
            var isAuthenticated = _customerService.ValidateUserAsync(username, password);
            if (!isAuthenticated)
            {
                return new LoginResponse { result = false, token = null };
            }

            // Kullanıcıyı bul
            var user = _customerService.GetUserByUsernameAsync(username);

            // Token oluştur
            var token = GenerateJwtToken(user.Id);

            return new LoginResponse { result=true, token = token };
        }

        private string GenerateJwtToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-secret-key"); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1), // Token'ın süresi
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
