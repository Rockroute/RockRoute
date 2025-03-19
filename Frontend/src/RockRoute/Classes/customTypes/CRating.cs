using System;
using System.Collections.Generic;
using RockRoute.Models;

namespace RockRoute.Classes {

    public class CRating {
        
        private string _userID = string.Empty;
        private int _rating;
        
        public string UserID {
            get => _userID;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("UserID cannot be null or empty.");
                    _userID = value; }
        }
        
        public int Rating {
            get => _rating;
            set {
                _rating = value;
            }
        }
        public CRating(string userID, int rating) {
            UserID = userID;
            Rating = rating;
        }
    }
}