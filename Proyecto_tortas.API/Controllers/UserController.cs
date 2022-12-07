using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto_tortas.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyecto_tortas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<AuthResponse>> Registrar(User user)
        {
            var usuario = new IdentityUser { UserName = user.UserName, Email = user.Email };
            var result = await userManager.CreateAsync(usuario, user.Password);
            if (result.Succeeded)
            {
                return GenerarToken(user);
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(User user)
        {
            var result = await signInManager.PasswordSignInAsync(user.UserName, user.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return GenerarToken(user);
            }
            else
            {
                return BadRequest("login incorrecto");
            }
        }

        private AuthResponse GenerarToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtkey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.Now.AddMonths(1);
            var token = new JwtSecurityToken(issuer: null, claims: claims, expires: expiration, signingCredentials: credential);
            return new AuthResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
