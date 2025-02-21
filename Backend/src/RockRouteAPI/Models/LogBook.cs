using system;
using System.Data.Entity;
using RockRoute.class
{
    
}

namespace RockRoute.Models //accessible from other areas of the project 
{
    public class LogBook //Defining a user
    {
        [ForeignKey(UserID)]
        public string UserID {get; set;}
        [ForeignKey(RouteID)]
        public string RouteID {get; set;}
        public <Playlist> Playlist  {get; set;}
        public <Route> Route  {get; set;}
        public  {get; set;}
    }

}