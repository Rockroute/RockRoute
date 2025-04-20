using RockRoute.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RockRoute.ViewModels
{
    public class LogBookTabViewModel
    {
        public ObservableCollection<Playlist> playlists {get;} = new(); 

        public LogBookTabViewModel() 
        {
            LoadPlaylists();
        }

        public void LoadPlaylists() {
            playlists.Add(new Playlist("test playlist","testCreator",new List<string>(),new List<string>(),null)
            {
                Name = "test-playlist",
                CreatorID = "testID"
            });
        }
    }
}