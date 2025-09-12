using DataLayer.Contexts;
using DataLayer.DTOs;
using DataLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController(TokenService service, AppDbContext context) : ControllerBase
    {
        [HttpPost("SignIn")]
        public IActionResult Login(LoginDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
                return BadRequest("Почта не указана");
            if (string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Пароль не указан");

            var dbEmployee = context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (dbEmployee == null)
                return NotFound("Пользователь не найден");

            string hashPassword = Hash(user.Password);
         
            if (dbEmployee.HashPassword != hashPassword)
                return StatusCode(403, "Доступ запрещён");
            return Ok(service.GenerateToken(dbEmployee));
        }

        public static string Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
