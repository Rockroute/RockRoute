using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic; //to use List

namespace RockRoute.Classes
{
    [Owned]
    public class Location
    {
        private double _lat;
        private double _long;

        public required double Lat {
            get => _lat;
            set => _lat = value;
        }
        public required double Long {
            get => _long;
            set => _long = value;
        }
        
        // Parameterless constructor for EF Core to use
        public Location() { }
        public Location (double lat, double lon) {
            Lat = lat;
            Long = lon;
        }
    }
}