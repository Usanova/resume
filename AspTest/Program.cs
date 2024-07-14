using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(
    i => i.ColorBehavior = LoggerColorBehavior.Enabled);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); 

var app = builder.Build();

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

//app.Run(async (context) =>
//{
//    var sb = new StringBuilder();
//    foreach (var h in context.Request.Headers)
//    {
//        sb.AppendLine($"{h.Key} - {h.Value}");
//    }

//    await context.Response.WriteAsync(sb.ToString());
//});

app.Run();