using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RockRoute.Classes {
[Owned]
    public class CRating {
        private string _userID = string.Empty;
        private int _rating;

        
        public required string UserID {
            get => _userID;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("UserID cannot be null or empty.");
                }
                _userID = value;
            }
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