using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RockRoute.Classes;


namespace RockRoute.Models //makes accessible from other areas of the project 
{
    public class Climb //Defining a climb
    {
        public string RouteName {get; set;}
        [Key] //[Key] makes RouteId primary key.
        public string RouteId {get; set;}
        public string SectorId {get; set;}
        public string ParentSector {get; set;}
        public string Type {get; set;}
        public string YDS {get; set;}
        public (float Lat, float Long) ParentLocation {get; set;}
        public string LocationDesciption {get; set;}
        public string ProtectionNotes {get; set;}
        public List<CRatings> UserRatings {get; set;} //List of Tuples with (String, int)
    }

    public class ClimbsDB : DbContext
    {
        public ClimbsDB(DbContextOptions<ClimbsDB> options) : base(options) {}
        public DbSet<Climb> Entries { get; set; } = null!;
    }

}