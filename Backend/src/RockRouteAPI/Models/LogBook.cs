using RockRoute.Classes;
using Microsoft.EntityFrameworkCore;


namespace RockRoute.Models //accessible from other areas of the project 
{
    public class LogBook //Defining a user
    {
        public string UserID { get; set; } // FK
        public string RouteID { get; set; } // FK
        public List<Playlist> Playlist {get; set;} // List of type Playlist defined in class
        
        public List<CRoute> Route  {get; set;}
        public List<Activity> Activity { get; set; }
    }

    class LogBooksDB : DbContext
    {
        public LogBooksDB(DbContextOptions options) : base(options) {}
        public DbSet<LogBook> Entries { get; set; } = null!;
    }
}
