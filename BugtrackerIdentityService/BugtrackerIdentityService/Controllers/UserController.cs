using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BugtrackerIdentityService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// TODO: password reset
// TODO: smart Email validation
// TODO: auth lockout after failed attempts
namespace BugtrackerIdentityService.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IdentityContext _context;

        public UserController(IdentityContext context)
        {
            _context = context;
        }
        
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody]AuthenticateDTO auth)
        {
            
            if (auth.Username == null || auth.Password == null)
                return BadRequest(new {message = "Username or Password is incorrect"});

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == auth.Username);

            if (user != null && user.IsCorrectPassword(auth.Password))
            {
                return Ok(CreateJwtPacket(user));
            }
            
            return BadRequest(new {message = "Username or Password are incorrect"});
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDTO register)
        {
            if (string.IsNullOrEmpty(register.Username) || string.IsNullOrEmpty(register.Password) || string.IsNullOrEmpty(register.Email))
                return BadRequest(new {message = "Username, password, and email are required"});
            // TODO : dumb email validation
            try
            {
                User newUser = new User(register.Username, register.Email, register.Password);
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return Ok(CreateJwtPacket(newUser));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            
        }

        private static JwtPacket CreateJwtPacket(User user)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("move this to configuration"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                // new Claim(JwtRegisteredClaimNames.UniqueName, user.Name) // will replace this with datetime
            };
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials));
            return new JwtPacket { Token = encodedJwt};
        }
    }

    internal class JwtPacket
    {
        public string Token { get; set; }
    }
}