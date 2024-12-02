var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();


var app = builder.Build();



app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

