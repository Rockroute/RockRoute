using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockRoute.Classes
{
    public class Activity
    {
        private long _iD;
        private string _name; 
        private DateTime? _date;
        private string _notes;



        [Key]
        public long Id
            {
                get => _iD;
                set {_iD = value;}
            }

        public string Name
        {
            get => _name;
@@ -33,7 +43,8 @@ public string Notes
                    _notes = value; }
        } 

        public Activity(string Name, DateTime? Date, string Notes) { //When initialising the Class
        public Activity(long Id, string Name, DateTime? Date, string Notes) { //When initialising the Class
            _iD = Id;
            _date = Date;
            _name = Name;
            _notes = Notes;
        }
    }
}