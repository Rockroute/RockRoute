using System;
using System.Collections.Generic;
using RockRoute.Models;


namespace RockRoute.Classes
{
    public class Activity
    {
        private string _name; 
        private DateTime? _date;
        private string _notes;


        public string Name
        {
            get => _name;
            set { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or empty.");
                    _name = value; }
        }

        public DateTime? Date 
        {
            get => _date;
            set { _date = value;}
        }

        public string Notes 
        {
            get => _notes; 
            set { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Notes cannot be null or empty.");
                    _notes = value; }
        } 

        public Activity(string Name, DateTime? Date, string Notes) { //When initialising the Class
            _date = Date;
            _name = Name;
            _notes = Notes;
        }
    }
}
