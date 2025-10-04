using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Task5.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private static readonly HashSet<int> ValidIds = new() { 1, 2, 3 };

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetUser([FromQuery] string? id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            _logger.LogWarning("Запрос без параметра id");
            return BadRequest(new { error = "ID is required", statusCode = 400 });
        }

        if (!int.TryParse(id, out int userId))
        {
            _logger.LogWarning("Неверный формат ID: {Id}", id);
            return BadRequest(new { error = "Invalid ID format", statusCode = 400 });
        }

        if (!ValidIds.Contains(userId))
        {
            _logger.LogWarning("Пользователь не найден: ID={UserId}", userId);
            return NotFound();
        }

        _logger.LogInformation("Пользователь найден: ID={UserId}", userId);
        return Ok(new { id = userId, name = $"User {userId}" });
    }

    [HttpGet("crash")]
    public IActionResult Crash() 
        => throw new InvalidOperationException("Тест глобального логирования!");
}