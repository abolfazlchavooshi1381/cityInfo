using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CityInfo.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        //public class AuthenticationRequestBody
        //{
        //    public string? UserName { get; set; }
        //    public string? Password { get; set; }
        //}

        //public class CityInfoUser
        //{
        //    public int UserId { get; set; }
        //    public string UserName { get; set; }
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public string City { get; set; }
        //}

        private readonly IConfiguration configuration;

        public AuthenticationController(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        [HttpPost("authenticate")]

        public ActionResult<string> Authenticate(AuthenticationRequestBodyDto authenticationRequestBody)
        {
            var user = ValidateUserCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim(ClaimTypes.Authentication, user.UserId.ToString()));
            claimsForToken.Add(new Claim("userId", user.UserId.ToString()));

            var jwtSecurityToken = new JwtSecurityToken(
                configuration["Authentication:Issuer"],
                configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.Now,
                DateTime.Now.AddHours(1000),
                signingCredentials
                );

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private CityInfoUser ValidateUserCredentials (string? userName, string? password)
        {
            return new CityInfoUser(1, userName??"", "Abolfazl", "Chavooshi", "Shahroud");
        }
    }
}
