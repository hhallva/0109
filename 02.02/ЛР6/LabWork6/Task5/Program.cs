using Microsoft.AspNetCore.Diagnostics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.MapControllers();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        logger.LogError(
            exceptionHandler?.Error,
            "Глобальная ошибка в API: {Path}",
            exceptionHandler?.Path
        );

        await context.Response.WriteAsJsonAsync(new
        {
            error = "Произошла внутренняя ошибка сервера.",
            statusCode = 500
        });
    });
});


app.Run();