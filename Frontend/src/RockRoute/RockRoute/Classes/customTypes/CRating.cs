using System;
using System.Collections.Generic; //to use List //This is needed in Frontend but not the backend setion?


namespace RockRoute.Classes {

    public class CRating {
        
        private string _userID = string.Empty;
        private int _rating;
        
        public required string UserID {
            get => _userID;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("UserID cannot be null or empty.");
                    _userID = value; }
        }
        
        public required int Rating {
            get => _rating;
            set {
                _rating = value;
            }
        }
        public CRating() {}
        public CRating(string userID, int rating) {
            UserID = userID;
            Rating = rating;
        }
    }
}