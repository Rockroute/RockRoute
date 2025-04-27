using System;
using System.Collections.Generic; //to use List

namespace RockRoute.Classes {
    public class Playlist {
        private string _name = string.Empty;
        private string _creatorID = string.Empty;
        private List<String>? _collabID;
        private List<String>? _listOfRoute_ID;
        private string? _playlistPicture;

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
        
        public string? PlaylistPicture {
            get => _playlistPicture;
            set {
                _playlistPicture = value;
            }
        }
        public Playlist() { }

        public Playlist(string name, string creatorID, List<string>? collabID, List<string>? ListOfRoute_ID, string? playlistPicture) {
            _name = name;
            _creatorID = creatorID;
            _collabID = collabID;
            _listOfRoute_ID = ListOfRoute_ID;
            _playlistPicture = playlistPicture;

        }  
    }
}