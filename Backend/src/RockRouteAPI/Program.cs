using RockRoute.Models;
using Microsoft.EntityFrameworkCore;

namespace RockRoute {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    builder.Services.AddDbContext<ClimbsDB>(opt =>
        opt.UseInMemoryDatabase("ClimbsDB"));
    builder.Services.AddDbContext<LogBooksDB>(opt =>
        opt.UseInMemoryDatabase("LogBooksDB"));
    builder.Services.AddDbContext<UsersDB>(opt =>
        opt.UseInMemoryDatabase("UsersDB"));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}