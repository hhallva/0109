using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Task5.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    // Мок-база: только пользователи с id 1, 2, 3 существуют
    private static readonly HashSet<int> ValidIds = new() { 1, 2, 3 };

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetUser([FromQuery] string? id)
    {
        // 1. Проверка: передан ли id
        if (string.IsNullOrWhiteSpace(id))
        {
            _logger.LogWarning("Запрос без параметра id");
            return BadRequest(new { error = "ID is required", statusCode = 400 });
        }

        // 2. Проверка: является ли id числом
        if (!int.TryParse(id, out int userId))
        {
            _logger.LogWarning("Неверный формат ID: {Id}", id);
            return BadRequest(new { error = "Invalid ID format", statusCode = 400 });
        }

        // 3. Проверка: существует ли пользователь
        if (!ValidIds.Contains(userId))
        {
            _logger.LogWarning("Пользователь не найден: ID={UserId}", userId);
            return NotFound(); // HTTP 404
        }

        // 4. Успех
        _logger.LogInformation("Пользователь найден: ID={UserId}", userId);
        return Ok(new { id = userId, name = $"User {userId}" });
    }

    [HttpGet("crash")]
    public IActionResult CrashTheServer()
    {
        // Это вызовет необработанное исключение
        return BadRequest(new { error = "Invalid ID format", statusCode = 500 });
        throw new InvalidOperationException("Сервер намеренно уничтожен.");
    }
}