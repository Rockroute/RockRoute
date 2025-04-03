using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockRoute.Classes {

    public class CRating {

    public class CRating {
        private string _userID = string.Empty;
        private int _rating;

        [Key]
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
        public CRating(string userID, int rating) {
            UserID = userID;
            Rating = rating;
        }
    }
}