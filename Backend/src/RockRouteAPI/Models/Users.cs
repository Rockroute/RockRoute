using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace RockRoute.Models //accessible from other areas of the project 
{
    public class User //Defining a user
    {
        [Key] // Primary key UserId.
        public string UserId {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public LogBook LogBook { get; set; } // Dependent navigation.
    }

    class UsersDB : DbContext
    {
        public UsersDB(DbContextOptions options) : base(options) {}
        public DbSet<User> Entries { get; set; } = null!;
    }

}