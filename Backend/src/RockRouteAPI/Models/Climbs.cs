using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace RockRoute.Models //accessible from other areas of the project 
{
    public class Climb //Defining a climb
    {
        public string RouteName {get; set;}
        [Key] // RouteId is primary key.
        public string RouteId {get; set;}
        public string SectorId {get; set;}
        public string ParentSector {get; set;}
        public string Type {get; set;}
        public string YDS {get; set;}
        public Tuple<float, float> ParentLocation {get; set;}
        public string LocationDesciption {get; set;}
        public string ProtectionNotes {get; set;}
        public List<Tuple<string, int>> UserRatings {get; set;}
    }

    class ClimbsDB : DbContext
    {
        public ClimbsDB(DbContextOptions options) : base(options) {}
        public DbSet<Climb> Entries { get; set; } = null!;
    }

}