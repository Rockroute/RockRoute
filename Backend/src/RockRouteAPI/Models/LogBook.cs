using RockRoute.Classes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RockRoute.Models //accessible from other areas of the project 
{
    public class LogBook //Defining a user
    {
        [Key]
        [ForeignKey(nameof(User))] // UserId FK to UsersDB.
        public string UserId { get; set; } 
        [ForeignKey(nameof(Climb))] // RouteId FK to ClimbsDB.
        public string RouteId { get; set; }
        public List<Playlist> Playlist {get; set;} // List of type Playlist defined in class
        
        public List<CRoute> Route  {get; set;}
        public List<Activity> Activity { get; set; }
        public User User { get; set; } // Dependent navigation.
        public Climb Climb { get; set; } // Dependent navigation.

    }

    class LogBooksDB : DbContext
    {
        public LogBooksDB(DbContextOptions options) : base(options) {}
        public DbSet<LogBook> Entries { get; set; } = null!;
    }
}
