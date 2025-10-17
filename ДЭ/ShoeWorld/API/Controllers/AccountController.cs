using DataLayer.Contexts;
using DataLayer.DTOs;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpPost("SingIn")]
        public async Task<ActionResult<DeUser>> LoginAsync(LoginDto dto)
        {
            var user = await _context.DeUsers.FirstOrDefaultAsync(u => u.Login == dto.Login);
            if (user == null)
                return NotFound();

            if (dto.Password != user.Password)
                return StatusCode(StatusCodes.Status403Forbidden);

            return Ok(user);
        }
    }
}
