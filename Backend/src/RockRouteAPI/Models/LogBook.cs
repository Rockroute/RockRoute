using RockRoute.Classes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RockRoute.Models //accessible from other areas of the project 
{
    public class LogBook //Defining a Logbook
    {
        [Key]
        [ForeignKey(nameof(User))] // UserId FK to UsersDB.
        public string UserId { get; set; } 
        [ForeignKey(nameof(Climb))] // RouteId FK to ClimbsDB.
        public string RouteId { get; set; }
        public string Playlist {get; set;} // List <Playlist> defined in class
        
        public string Route  {get; set;} //List<CRoute>
        public string Activity { get; set; } //List<Activity>
        public string User { get; set; } // Type user
        public string Climb { get; set; } // Type Climb

    }

    class LogBooksDB : DbContext
    {
        public LogBooksDB(DbContextOptions options) : base(options) {}
        public DbSet<LogBook> Entries { get; set; } = null!;
    }
}
