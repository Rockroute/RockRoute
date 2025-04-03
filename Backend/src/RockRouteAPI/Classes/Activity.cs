using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace RockRoute.Classes
{
    [Owned]
    public class Activity
    {
        private string _name;
        private DateTime? _date;
        private string _notes;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public DateTime? Date
        {
            get => _date;
            set => _date = value;
        }

        public string Notes
        {
            get => _notes;
            set => _notes = value;
        }

        public Activity(string name, DateTime? date, string notes)
        {
            _name = name;
            _date = date;
            _notes = notes;
        }
    }
}
