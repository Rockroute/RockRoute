using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RockRoute.Classes {
    [Owned]

    public class CRoute {
        private string _routeID = string.Empty;
        private DateTime? _completeDate;
        private List<string>? _partnerID;
        private int? _attempts;
        private bool? _isOnSite;
        private string? _notes;

        public required string RouteID {
            get => _routeID;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("RouteID cannot be null or empty.");
                }
                _routeID = value;
            }
        }

        public DateTime? CompletedDate {
            get => _completeDate;
            set => _completeDate = value;
        }

        public List<string>? PartnerID {
            get => _partnerID;
            set => _partnerID = value;
        }

        public int? Attempts {
            get => _attempts;
            set => _attempts = value;
        }

        public bool? IsOnSite {
            get => _isOnSite;
            set => _isOnSite = value;
        }

        public string? Notes {
            get => _notes;
            set => _notes = value;
        }

        public CRoute(string routeID, DateTime? completedDate, List<string>? partnerID, int? attempts, bool? isOnSite, string? notes) {
            RouteID = routeID;
            CompletedDate = completedDate;
            PartnerID = partnerID;
            Attempts = attempts;
            IsOnSite = isOnSite;
            Notes = notes;
        }
    }
}
