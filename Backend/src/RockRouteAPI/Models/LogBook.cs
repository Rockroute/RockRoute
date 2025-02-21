using system;
using System.Data.Entity;

namespace RockRoute.Models //accessible from other areas of the project 
{
    public class LogBook //Defining a user
    {
        [ForeignKey(UserID)]
        public string UserID {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }

}