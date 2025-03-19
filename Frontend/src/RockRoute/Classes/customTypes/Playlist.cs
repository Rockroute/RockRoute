using System;
using System.Collections.Generic;
using RockRoute.Models;

namespace RockRoute.Classes {
    public class Playlist {
        private string _name = string.Empty;
        private string _creatorID = string.Empty;
        private List<String>? _collabID;
        private List<CRoute>? _listOfRoutes = new List<CRoute>();
        private byte[]? _playlistPicture;

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
        public List<CRoute>? ListOfRoutes {
            get => _listOfRoutes;
            set {
                _listOfRoutes = value;}
        }
        public byte[]? PlaylistPicture {
            get => _playlistPicture;
            set {
                _playlistPicture = value;
            }
        }

        public Playlist(string name, string creatorID, List<string>? collabID, List<CRoute>? listOfRoutes, byte[]? playlistPicture) {
            _name = name;
            _creatorID = creatorID;
            _collabID = collabID;
            _listOfRoutes = listOfRoutes;
            _playlistPicture = playlistPicture;

        }  
    }
}