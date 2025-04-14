using RockRoute.Classes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RockRoute.Models //accessible from other areas of the project 
{

    public class LogBook //Defining a Logbook
    {
        [Key]
        [ForeignKey(nameof(User))] // UserId FK to UsersDB. Only links it doesnt define it
        public required string UserId { get; set; }

        [ForeignKey(nameof(Climb))] // RouteId FK to ClimbsDB. Only links it doesnt define it
        public required string RouteId { get; set; } = " ";
        public required List<Playlist> Playlist { get; set; } // List <Playlist> defined in class

        public required List<CRoute> Route { get; set; } //List<CRoute>
        public required List<Activity> Activity { get; set; } //List<Activity>

    }

    class LogBooksDB : DbContext
    {
        public LogBooksDB(DbContextOptions<LogBooksDB> options) : base(options) { }
        public DbSet<LogBook> Entries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogBook>().OwnsMany(lb => lb.Route);
            modelBuilder.Entity<LogBook>().OwnsMany(lb => lb.Activity);
            modelBuilder.Entity<LogBook>().OwnsMany(lb => lb.Playlist);

            base.OnModelCreating(modelBuilder);
        }


    }
}
