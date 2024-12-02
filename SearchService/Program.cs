using SearchService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();


var app = builder.Build();

await DbInitializer.InitDb(app);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

