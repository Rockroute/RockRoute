using RockRoute.Classes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; //to use List //This is needed in Frontend but not the backend setion?



namespace RockRoute.Models //accessible from other areas of the project 
{

    public class LogBook //Defining a Logbook
    {
        [Key]
        [ForeignKey(nameof(User))] // UserId FK to UsersDB. Only links it doesnt define it
        public required string UserId { get; set; }
        
        [ForeignKey(nameof(Climb))] // RouteId FK to ClimbsDB. Only links it doesnt define it
        public required string RouteId { get; set; } = " ";
        public required List<Playlist> Playlist {get; set;} // List <Playlist> defined in class
        
        public required List<CRoute> Route  {get; set;} //List<CRoute>
        public required List<Activity> Activity { get; set; } //List<Activity>

    }

    class LogBooksDB : DbContext
    {
        public LogBooksDB(DbContextOptions options) : base(options) {}
        public DbSet<LogBook> Entries { get; set; } = null!;
    }
}
