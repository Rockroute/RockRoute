using System;

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
            set { _name = value;}
        }

        public DateTime? Date 
        {
            get => _date;
            set { _date = value;}
        }

        public string Notes 
        {
            get => _notes: 
            set { _notes = value;}
        } 

        public Activity(string Name, DateTime Date, Notes) { //When initialising the Class
            this._date = Date
            this._name = Name
            this._notes = Notes
        }
    }
}