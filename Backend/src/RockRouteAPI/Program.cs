using RockRoute.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<ClimbsDB>(opt => opt.UseInMemoryDatabase("ClimbsDB"));
builder.Services.AddDbContext<LogBooksDB>(opt => opt.UseInMemoryDatabase("LogBooksDB"));
builder.Services.AddDbContext<UsersDB>(opt => opt.UseInMemoryDatabase("UsersDB"));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
//dotnet aspnet-codegenerator controller -name ClimbsDBController -async -api -m Climb -dc ClimbsDB -outDir Controllers
//dotnet aspnet-codegenerator controller -name LogBookDBController -async -api -m LogBook -dc LoogBooksDB -outDir Controllers
//dotnet aspnet-codegenerator controller -name ClimbsDBController -async -api -m Climb -dc ClimbsDB -outDir Controllers