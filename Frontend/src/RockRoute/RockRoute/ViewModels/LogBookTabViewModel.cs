using RockRoute.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RockRoute.ViewModels
{
    public class LogBookTabViewModel
    {
        public ObservableCollection<Playlist> playlists {get;} = new(); 
        public ObservableCollection<string> colabIDs {get;} = new(); 

        public LogBookTabViewModel() 
        {
            LoadPlaylists();
        }

        public List<string> Test(List<string> list) {
            list.Add("c");
            list.Add("c");
            list.Add("c");
            list.Add("c");
            return list;
        }

        public void LoadPlaylists() {
            playlists.Add(new Playlist("test playlist","testCreator",new List<string>(),Test(new List<string>()),null)
            {
                Name = "test-playlist",
                CreatorID = "testID"
            });
            playlists.Add(new Playlist("test playlist","testCreator",new List<string>(),Test(new List<string>()),null)
            {
                Name = "test-playlist",
                CreatorID = "testID"
            });
        }

        public void LoadcolabIDs() {
            colabIDs.Add("");
        }

        public void AddCollaborator() {
            colabIDs.Add("");
        }

        public void RemoveCollaborator() {
            if (colabIDs.Count >= 1){
                colabIDs.RemoveAt(colabIDs.Count - 1);
            }
        }
    }
}