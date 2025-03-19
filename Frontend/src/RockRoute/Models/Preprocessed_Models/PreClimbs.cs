using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RockRoute.Classes;


namespace RockRoute.Models //makes accessible from other areas of the project 
{
    [Owned] 
    public class Climb //Defining a climb

    {
        public required string RouteName {get; set;}
        [Key] //[Key] makes RouteId primary key.
        public required string RouteId {get; set;}
        public required string SectorId {get; set;}
        public required string ParentSector {get; set;}
        public required string Type {get; set;}
        public required string YDS {get; set;}
        public required(float Lat, float Long) ParentLocation {get; set;}
        public required string LocationDescription {get; set;}
        public required string ProtectionNotes {get; set;}
        public required string UserRatings {get; set;} //List of Tuples with (String, int)
    }

    public class ClimbsDB : DbContext
    {
        public ClimbsDB(DbContextOptions<ClimbsDB> options) : base(options) {}
        public DbSet<Climb> Entries { get; set; } = null!;
    }

}