using CRM.API.Helpers;
using CRM.Shared.DTOs;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("/api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IUserHelper _userHelper;
        private readonly IConfiguration _configuration;

        public AccountsController(IUserHelper userHelper, IConfiguration configuration)
        {
            _userHelper = userHelper;
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] UserDTO model)
        {
            /*Recibimos el modelo que contiene todos las propiedades de un usuario junto con su contraseña*/
            Users user = model;
            var result = await _userHelper.AddUserAsync(user, model.Password); /*Creamos el usuario*/
            if (result.Succeeded)
            {
                await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString()); /*Se asigna el rol*/
                return Ok(BuildToken(user));
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }


        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO model)
        {
            var result = await _userHelper.LoginAsync(model);
            if (result.Succeeded)
            {
                var user = await _userHelper.GetUserAsync(model.Email);
                return Ok(BuildToken(user));
            }

            return BadRequest("Email o contraseña incorrectos.");
        }

        private TokenDTO BuildToken(Users user) /*Generamos el token junto con su expiración*/
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email!),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }

}
