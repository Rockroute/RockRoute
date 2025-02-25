using RockRoute.Models;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<ClimbsDB>(opt => opt.UseInMemoryDatabase("ClimbsDB"));
builder.Services.AddDbContext<LogBooksDB>(opt => opt.UseInMemoryDatabase("LogBooksDB"));
builder.Services.AddDbContext<UsersDB>(opt => opt.UseInMemoryDatabase("UsersDB"));

builder.Services.AddControllers();
if (builder.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    builder.Services.AddSwaggerGen(c =>{
        c.SwaggerDoc("v1", new OpenApiInfo {Title = "RockRouteAPI", Description = "Climbing route locator system", Version = "v1"});
    });
}
var app = builder.Build();

if(builder.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RockRouteAPI V1");
    });
}
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();



app.Run();
//dotnet aspnet-codegenerator controller -name ClimbsDBController -async -api -m Climb -dc ClimbsDB -outDir Controllers
//dotnet aspnet-codegenerator controller -name LogBookDBController -async -api -m LogBook -dc LogBooksDB -outDir Controllers
//dotnet aspnet-codegenerator controller -name UsersDBController -async -api -m User -dc UsersDB -outDir Controllers