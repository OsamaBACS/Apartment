using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Dtos;
using BackEnd.Interfaces;
using BackEnd.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;
        public AccountController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.uow = uow;

        }

        // api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> login(LoginReqDto loginReq)
        {
            var user = await uow.userRepository.Authenticate(loginReq.Username, loginReq.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var loginRes = new LoginResponseDto();
            loginRes.UserName = user.Username;
            loginRes.Token = CreateJWT(user);

            return Ok(loginRes);
        }

        //         JWT=> JSON Web Token
        public string CreateJWT(User user)
        {
            var secreteKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var signingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = signingCredential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}