using System;
using Microsoft.EntityFrameworkCore;


namespace RockRoute.Models //accessible from other areas of the project 
{
    public class Climb //Defining a climb
    {
        public string RouteName {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }

    class ClimbsDB : DbContext
    {
        public ClimbsDB(DbContextOptions options) : base(options) {}
        public DbSet<Climb> Entries { get; set; } = null!;
    }

}