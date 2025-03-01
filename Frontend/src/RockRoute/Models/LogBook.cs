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
        public required string UserId { get; set; }
        [ForeignKey(nameof(Climb))] // RouteId FK to ClimbsDB.
        public required string RouteId { get; set; } = " ";
        public required string Playlist {get; set;} // List <Playlist> defined in class
        
        public required List<Croute> Route  {get; set;} //List<CRoute>
        public required List<Activity> Activity { get; set; } //List<Activity>
        public required User User { get; set; } // Type user
        public required Climb Climb { get; set; } // Type Climb

    }

    class LogBooksDB : DbContext
    {
        public LogBooksDB(DbContextOptions options) : base(options) {}
        public DbSet<LogBook> Entries { get; set; } = null!;
    }
}
