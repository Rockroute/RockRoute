using system;
using System.Data.Entity;
using RockRoute.classes;

namespace RockRoute.Models //accessible from other areas of the project 
{
    public class LogBook //Defining a user
    {
        public string UserID { get; set; } //FK
        public string RouteID { get; set; } //FK
        public List<Playlist> Playlist {get; set;} //List of type Playlist defined in class
        
        public List<Route> Route  {get; set;}
        public List<Activity> Activity { get; set; }
    }
}
