using BusinessLayer.Abstract;
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

        public async Task<(bool, string)> LoginAsync(string username, string password)
        {
            // Kullanıcı doğrulaması yap
            var isAuthenticated = await _customerService.ValidateUserAsync(username, password);
            if (!isAuthenticated)
            {
                return (false, null);
            }

            // Kullanıcıyı bul
            var user = await _customerService.GetUserByUsernameAsync(username);

            // Token oluştur
            var token = GenerateJwtToken(user.id);

            return (true, token);
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
