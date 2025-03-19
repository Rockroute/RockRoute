using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace RockRoute.Models //accessible from other areas of the project 
{
    public class User //Defining a user
    {
        [Key] // Primary key UserId.
        public required string UserId {get; set;}
        public required string Name {get; set;}
        public required string Email {get; set;}
        public required string Password {get; set;}
    }

    public class UsersDB : DbContext
    {
        public UsersDB(DbContextOptions options) : base(options) {}
        public DbSet<User> Entries { get; set; } = null!;
    }

}