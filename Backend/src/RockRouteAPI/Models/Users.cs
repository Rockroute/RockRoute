using system;
using System.Data.Entity;

namespace RockRoute.Models //accessible from other areas of the project 
{
    public class User //Defining a user
    {
        public string UserID {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }

    public class UsersDB : DbContext //Defining UsersDB as a list of Users
    {
        public DbSet<User> Users {get; set;}
    }

}