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
        // needs to load up the playlists
        public void LoadPlaylists() {
            
            //playlist playfromAPI new plaulist
            //playlist.Add(playfromAPI)
            playlists.Add(new Playlist("test playlist","testCreator",new List<string>(),new List<string>(),null)
            {
                //This is where you add the playlist from API
                Name = "test-playlist-1",
                CreatorID = "testID"
            });
            playlists.Add(new Playlist("test playlist","testCreator",new List<string>(),new List<string>(),null)
            {
                Name = "test-playlist-2",
                CreatorID = "testID"
            });

            /*
            string path = "api/LogBookDB/"+ Program.loggedInUser.UserId;
            LogBook retrievedLogBook = await API_Logbooks.GetLogbookAsync(path);

            if (retrievedLogBook.Playlist != null) {
                
                foreach (Playlist UserPlaylist in retrievedLogBook.Playlist) {
                    playlists.Add(UserPlaylist);
                }
            }
            */
        }
        // restest the collection and then reloads the playists 
        public void ReloadPlaylists() {
            while (playlists.Count > 0) {
                playlists.RemoveAt(0);
            }
            LoadPlaylists();
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