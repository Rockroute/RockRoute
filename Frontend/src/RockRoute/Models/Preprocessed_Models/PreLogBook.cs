using RockRoute.Classes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RockRoute.PreModels //accessible from other areas of the project 
{
    public class PreLogBook //Defining a Logbook
    {
        [Key]
        [ForeignKey(nameof(User))] // UserId FK to UsersDB.
        public required string UserId { get; set; }
        [ForeignKey(nameof(Climb))] // RouteId FK to ClimbsDB.
        public required string RouteId { get; set; } = " ";
        public required string Playlist {get; set;} // List <Playlist> defined in class
        
        public required string Route  {get; set;} //List<CRoute>
        public required string Activity { get; set; } //List<Activity>
        public required string User { get; set; } // Type user
        public required string Climb { get; set; } // Type Climb

    }

}
