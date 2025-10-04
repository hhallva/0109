using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


app.UseRouting();
app.MapControllers();

// ���������� ���������� �������������� ���������� � middleware
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        await LogExceptionAsync(ex, "�������������� ���������� � HTTP-�������");
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new { error = "Internal server error", statusCode = 500 });
    }

});
static async Task LogExceptionAsync(Exception ex, string message)
{
    var logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}\n" +
                  $"���: {ex.GetType().Name}\n" +
                  $"���������: {ex.Message}\n" +
                  $"����: {ex.StackTrace}\n" +
                  new string('-', 50) + "\n";

    // ����� � ������������ (��� ������) ���� app.log
    await File.AppendAllTextAsync("app.log", logLine, Encoding.UTF8);
}
app.Run();