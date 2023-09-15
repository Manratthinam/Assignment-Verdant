using Application.Core.Auth.LogIn.Query;
using Application.Core.Auth.SignIn.Command;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TCourtBooking.Controllers
{
    public class AuthController : BaseController<AuthController>
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SigIn([FromBody] SiginEntity signIn)
        {
            try
            {
                var createUser = await Mediator.Send(new SigInCommand(signIn));
                return Ok("User created Successfullt");
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInEntity login)
        {
            if(!ModelState.IsValid) {
                return BadRequest("check your email and password");
            }
            try
            {
                var user = await Mediator.Send(new CheckUserExistQuery(login.Email));
                if(user == null)
                {
                    return BadRequest("User not Exist");
                }
                else if(user.Password != login.Password)
                {
                    return BadRequest("Password Does not match");
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new (ClaimTypes.Name,user.FirstName),
                        new (ClaimTypes.Email,user.Email),
                        new (ClaimTypes.Sid,user.Id.ToString())
                    };
                    var claimIdentity = new ClaimsIdentity(claims,"JWT_OR_Cookie");
                    await HttpContext.SignInAsync("JWT_OR_Cookie",
                        new ClaimsPrincipal(claimIdentity),
                        new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTime.UtcNow.AddHours(24),
                            IssuedUtc = DateTime.UtcNow,
                            IsPersistent = true,
                        }
                        );
                    return Ok("Logged In");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Ok("Logged Out");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GenerateJwtToken()
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("250992e1-67ce-4f4e-b00c-5ff858fabfed"));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new SecurityTokenDescriptor
            {
                Audience = "TCourt",
                Issuer = "TCourt",
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = credentials
            };
            var tokenGenerated = new JwtSecurityTokenHandler();
            var tokenCreate = tokenGenerated.CreateToken(token);
            return Ok(tokenGenerated.WriteToken(tokenCreate)); 
        }
    }
}
