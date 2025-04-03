using System;
using System.ComponentModel.DataAnnotations;

namespace RockRoute.Classes
{
    public class Activity
    {
        private long _id;
        private string _name;
        private DateTime? _date;
        private string _notes;

        [Key]
        public long Id
        {
            get => _id;
            set => _id = value;
        }

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

        public Activity(long id, string name, DateTime? date, string notes)
        {
            _id = id;
            _name = name;
            _date = date;
            _notes = notes;
        }
    }
}
