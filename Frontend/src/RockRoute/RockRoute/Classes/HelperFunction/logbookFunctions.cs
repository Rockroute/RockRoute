using System.Collections.Generic; //to use List
using Newtonsoft.Json;//for JSON serilization
using System.Threading.Tasks;

using RockRoute.enums;
using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.ApiTest;
using System;

namespace RockRoute.Helper
{
    public static class LogBookFunctions
    {


        public async static Task<LogBook> findLogbookFromId(string InputUserId) //Works
        {
            //Input userid, Returns the User
            List<LogBook> retrievedLogbook = await API_Logbooks.GetAllLogbooksAsync("api/LogbookDB");
            if (retrievedLogbook.Count > 0)
            {
                //If user do exist, then go through all
                foreach (var oneLogbook in retrievedLogbook)
                {
                    ////System.Console.WriteLine(oneUser.Email.ToLower());
                    if (oneLogbook.UserId.ToLower() == InputUserId.ToLower())
                    {
                        return (oneLogbook);
                    }
                }

            }
            else
            {
                //System.Console.WriteLine("No Users not found");
            }
            //If no users or No users match
            return (null);

        }

        public async static Task<bool> newPlaylist(string InputUserId, string playlistName, List<string> collabIds)
        {
            var logbook = await LogBookFunctions.findLogbookFromId(InputUserId);

            List<string> NewCollabID = collabIds;
            if (NewCollabID == null)
            {
                NewCollabID = new List<string> { InputUserId };
            }


            if (logbook == null)
            {
                //System.Console.WriteLine("Logbook not exists!!! but will make it now");

                var NewActivity = new Activity(
                Name: "Activity",
                Date: DateTime.Now,
                Notes: "Notes"
                );


                var NewPlaylist = new Playlist
                {
                    Name = playlistName,
                    CreatorID = InputUserId,
                    CollabID = NewCollabID,
                    ListOfRoute_ID = new List<string> { "Example" },
                    PlaylistPicture = "image_url_here"
                };


                var NewRoute = new CRoute
                {
                    RouteID = "Example",
                    CompletedDate = DateTime.Now,
                    PartnerID = new List<string> { InputUserId },
                    Attempts = 1,
                    IsOnSite = true,
                    Notes = "Note"
                };



                var NewlogBook = new LogBook
                {
                    UserId = InputUserId,
                    RouteId = "TEST",
                    Playlist = new List<Playlist> { NewPlaylist },
                    Route = new List<CRoute> { NewRoute },
                    Activity = new List<Activity> { NewActivity }
                };


                //Then save the new logbook
                try
                {
                    await API_Logbooks.CreateLogbookAsync(NewlogBook);
                    //System.Console.WriteLine("New logbook created!");
                    return true;
                }
                catch (Exception ErrorNOOOO)
                {
                    //System.Console.WriteLine(ErrorNOOOO.Message);
                    return false;
                }
            }
            else
            {



                var NewPlaylist = new Playlist
                {
                    Name = playlistName,
                    CreatorID = InputUserId,
                    CollabID = NewCollabID,
                    ListOfRoute_ID = new List<string> { "Example" },
                    PlaylistPicture = "image_url_here"
                };

                if (logbook.Playlist == null)
                {
                    logbook.Playlist = new List<Playlist>();
                }
                logbook.Playlist.Add(NewPlaylist);


                try
                {
                    var updatedLogbook = await API_Logbooks.UpdateLogbookAsync(logbook);
                    //System.Console.WriteLine("Logbook updated!!");

                    //System.Console.WriteLine(JsonConvert.SerializeObject(updatedLogbook, Formatting.Indented));

                    return true;
                }
                catch (Exception ErrorNOOOO)
                {
                    //System.Console.WriteLine("Error while updating logbook: " + ErrorNOOOO.Message);
                    return false;
                }


            }

            public async void AddClimbToPlaylist(string ) {

        }



        public async static Task<bool> newActivity(string InputUserId, string InputActivityName, string InputDescription, DateTime InputDate)
        {
            var logbook = await LogBookFunctions.findLogbookFromId(InputUserId);

            if (logbook == null)
            {
                //logbook no exist
                var NewActivity = new Activity(
                    Name: InputActivityName,
                    Date: InputDate,
                    Notes: InputDescription
                );

                var NewlogBook = new LogBook
                {
                    UserId = InputUserId,
                    RouteId = "TEST",
                    Playlist = new List<Playlist>(),
                    Route = new List<CRoute>(),
                    Activity = new List<Activity> { NewActivity }
                };

                try
                {
                    await API_Logbooks.CreateLogbookAsync(NewlogBook);
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
            else
            {
                //LogBook exists
                var NewActivity = new Activity(
                    Name: InputActivityName,
                    Date: InputDate,
                    Notes: InputDescription
                );

                if (logbook.Activity == null)
                {
                    logbook.Activity = new List<Activity>();
                }

                logbook.Activity.Add(NewActivity);

                try
                {
                    await API_Logbooks.UpdateLogbookAsync(logbook);
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
        }



        public async static Task<bool> newClimb(string InputUserId, string InputPlaylistName, CRoute  InputNewClimb)
        {
            var logbook = await LogBookFunctions.findLogbookFromId(InputUserId);

            if (logbook == null)
            {
                //logbook not exist and make a new logbook
                var NewPlaylist = new Playlist
                {
                    Name = InputPlaylistName,
                    CreatorID = InputUserId,
                    CollabID = new List<string> { InputUserId },
                    ListOfRoute_ID = new List<string> {  InputNewClimb.RouteID },
                    PlaylistPicture = "defaultImageMaybe"
                };

                var NewlogBook = new LogBook
                {
                    UserId = InputUserId,
                    RouteId = "TEST",
                    Playlist = new List<Playlist> { NewPlaylist },
                    Route = new List<CRoute> {  InputNewClimb },
                    Activity = new List<Activity>()
                };

                try
                {
                    await API_Logbooks.CreateLogbookAsync(NewlogBook);
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
            else
            {
                if (logbook.Playlist == null)
                {
                    logbook.Playlist = new List<Playlist>();
                }

                Playlist playlist = null;
                foreach (var onePlaylist in logbook.Playlist)
                {
                    if (onePlaylist.Name.ToLower() == InputPlaylistName.ToLower())
                    {
                        playlist = onePlaylist;
                        break;
                    }

                }

                if (playlist == null)
                {
                    // playlist doesn't exist, not logbook dont get confused sam -- Harvey
                    playlist = new Playlist
                    {
                        Name = InputPlaylistName,
                        CreatorID = InputUserId,
                        CollabID = new List<string> { InputUserId },
                        ListOfRoute_ID = new List<string>(),
                        PlaylistPicture = "defaultImageMaybe"
                    };
                    logbook.Playlist.Add(playlist);
                }

                if (playlist.ListOfRoute_ID == null)
                {
                    playlist.ListOfRoute_ID = new List<string>();
                    //new if not exist
                }

                playlist.ListOfRoute_ID.Add( InputNewClimb.RouteID);

                if (logbook.Route == null)
                {
                    logbook.Route = new List<CRoute>();
                    //new if not exist

                }

                logbook.Route.Add( InputNewClimb);

                try
                {
                    await API_Logbooks.UpdateLogbookAsync(logbook);
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
        }








    }
}
