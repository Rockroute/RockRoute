using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RockRoute.Classes;
using System.Collections.Generic; //to use List //This is needed in Frontend but not the backend setion?

using RockRoute.enums;


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
        public required climbTypes Type {get; set;} 
        public required string YDS {get; set;}
        public required (double Lat, double Long) ParentLocation {get; set;}
        public required string LocationDescription {get; set;}
        public required string Protection_Notes {get; set;}
        public required List<CRating> UserRatings {get; set;} //List of Tuples with (String, int)
    }

    public class ClimbsDB : DbContext
    {
        public ClimbsDB(DbContextOptions<ClimbsDB> options) : base(options) {}
        public DbSet<Climb> Entries { get; set; } = null!;
    }

}