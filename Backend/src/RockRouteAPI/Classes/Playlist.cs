using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; //to use List

namespace RockRoute.Classes {
    public class Playlist {
        private long _iD;
        private string _name = string.Empty;
        private string _creatorID = string.Empty;
        private List<String>? _collabID;
        /*
        We dont want a list of routes, Cause we have to define the routes 
        when defining pLaylist, Leading to when defining Logbook.
            We are better of just doing list of routeID, 
            then a helper function will match them up
        */
        private List<String>? _listOfRoute_ID;
        private byte[]? _playlistPicture;

        [Key]
        public long Id {
            get => _iD;
            set {_iD = value;}
        }
        public required string Name {
            get => _name;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or empty.");
                    _name = value; }
        }
        public required string CreatorID {
            get => _creatorID;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CreatorID cannot be null or empty.");
                    _creatorID = value; }
        }
        public List<String>? CollabID {
            get => _collabID;
            set {
                _collabID = value; 
            }
        }
        
        public List<String>? ListOfRoute_ID {
            get => _listOfRoute_ID;
            set {
                _listOfRoute_ID = value;}
        }
        
        public byte[]? PlaylistPicture {
            get => _playlistPicture;
            set {
                _playlistPicture = value;
            }
        }
        public Playlist(long Id, string name, string creatorID, List<string>? collabID, List<string>? ListOfRoute_ID, byte[]? playlistPicture) {
            _iD = Id;
            _name = name;
            _creatorID = creatorID;
            _collabID = collabID;
            _listOfRoute_ID = ListOfRoute_ID;
            _playlistPicture = playlistPicture;

        }  
    }
}